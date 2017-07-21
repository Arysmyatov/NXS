using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;
using OfficeOpenXml;

namespace NXS.Services.Excel
{
    public class ExcelImportDataService : IExcelImportDataService
    {
        #region Constants

        private const string ByRegionSheetName = "By region";
        private const string GlobalResultsSheetName = "Global Results";
        private const string GeneralParametersSheetName = "General parameters";

        private const byte RegionRow = 1;
        private const byte RegionCol = 2;

        #endregion

        private readonly IScenarioRepository _scenarioRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IVariableRepository _variableRepository;
        private readonly ISubVariableRepository _subVariableRepository;
        private readonly IDataRepository _dataRepository;
        private readonly NxsDbContext _context;
        private readonly UnitOfWork _unitOfWork;
        public string WorkBookBasePath { get; set; }

        public ExcelImportDataService(IScenarioRepository scenarioRepository,
                                        IRegionRepository regionRepository,
                                        IVariableRepository variableRepository,
                                        ISubVariableRepository subVariableRepository,
                                        IDataRepository dataRepository,
                                        UnitOfWork unitOfWork,
                                        NxsDbContext context)
        {
            _scenarioRepository = scenarioRepository;
            _regionRepository = regionRepository;
            _variableRepository = variableRepository;
            _subVariableRepository = subVariableRepository;
            _scenarioRepository = scenarioRepository;
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ImportData()
        {
            var scenarios = await _scenarioRepository.GetScenarios(null);
            var keyParameters = _context.KeyParameters;
            var keyParameterLevels = _context.KeyParameterLevels;

            foreach (var scenario in scenarios.Items)
            {
                foreach (var keyParameter in keyParameters)
                {
                    foreach (var keyParameterLevel in keyParameterLevels)
                    {
                        var xlsFile = _context.XlsUploads.FirstOrDefault(x => x.ScenarioId == scenario.Id &&
                                                                              x.KeyParameterId == keyParameter.Id &&
                                                                              x.KeyParameterLevelId == keyParameterLevel.Id);

                        // Open file
                        var filePath = $"{WorkBookBasePath}/{xlsFile.FileName}";
                        var fileInfo = new FileInfo(filePath);

                        var regions = _context.Regions;
                        var variableXls = _context.VariableXls;

                        // Open Xls file
                        using (var package = new ExcelPackage(fileInfo))
                        {
                            // Set sheet for the region data
                            var regionSheet = package.Workbook.Worksheets[ByRegionSheetName];

                            foreach (var region in regions)
                            {
                                // change current region in xls 
                                regionSheet.Cells[RegionRow, RegionCol].Value = region.Name;

                                foreach (var varXls in variableXls)
                                {
                                    var years = GetYears(varXls, regionSheet);

                                    var variable = await _variableRepository.GetVariable(varXls.VariableId);
                                    if(variable == null ||
                                       variable.Name == "GDP" ||
                                       variable.Name == "Population" ){
                                           continue;
                                    }

                                    for (var row = varXls.DataBgRow; row <= varXls.DataEndRow; row++)
                                    {
                                        var subVariableName = regionSheet.Cells[RegionRow, varXls.DataBgCol].Value.ToString();

                                        var subVariable = await GetSubVariable(subVariableName);
                                        if (subVariable == null)
                                        {
                                            // create new sub variable
                                            subVariable = await CreateNewSubVariable(subVariableName);
                                        }

                                        var yearIndex = 0;
                                        for (var col = varXls.DataBgCol + 1; col <= varXls.DataEndCol; col++)
                                        {
                                            var dataVal = regionSheet.Cells[row, col].Value;
                                            if (dataVal == null) continue;

                                            string dataValStr = string.Empty;
                                            try
                                            {
                                                dataValStr = dataVal.ToString();
                                            }
                                            catch (Exception ex)
                                            {
                                                // ToDo: log cach error
                                                continue;
                                            }

                                            // Create and save data

                                            var data = new Data {
                                                RegionId = region.Id,
                                                ScenarioId = scenario.Id,
                                                KeyParameterId = keyParameter.Id,
                                                KeyParameterLevelId = keyParameterLevel.Id,
                                                VariableId = varXls.VariableId,
                                                SubVariableId = subVariable.Id,
                                                Year = years[yearIndex],
                                                Value = decimal.Parse(dataValStr)
                                            };

                                            _dataRepository.Add(data);
                                            await _unitOfWork.CompleteAsync();

                                            yearIndex++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string[] GetYears(VariableXls variableXls, ExcelWorksheet workSheet)
        {
            var yeras = new string[variableXls.YearBgCol - variableXls.YearBgCol + 1];
            var yearIndex = 0;

            for (var col = variableXls.YearBgCol; col <= variableXls.YearBgCol; col++)
            {
                var yearVal = workSheet.Cells[variableXls.YearBgRow, col].Value;
                if (yearVal == null)
                {
                    continue;
                }
                yeras[yearIndex] = yearVal.ToString();
                yearIndex++;
            }

            return yeras;
        }

        private async Task<SubVariable> GetSubVariable(string name)
        {
            var subVariables = await _subVariableRepository.GetSubVariables(new SubVariableQuery { Name = name });

            return subVariables.Items.FirstOrDefault();
        }

        private async Task<SubVariable> CreateNewSubVariable(string name)
        {
            // create new sub variable
            var subVariable = new SubVariable { Name = name };
            _subVariableRepository.Add(subVariable);
            await _unitOfWork.CompleteAsync();

            return subVariable;
        }
    }
}