using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions;
using OfficeOpenXml;

namespace NXS.Services.Excel.DataImport
{
    public class XlsImportVariableDataService : IXlsImportVariableDataService
    {
        public int CurrentScenarioId { get; set; }
        public int CurrentKeyParameterId { get; set; }
        public int CurrentKeyParameterLevelId { get; set; }
        public int CurrentParentRegionId { get; set; }
        public ExcelWorkbook CurrentWorkBook { get; set; }
        public string _workBookBasePath { get; set; }
        private readonly IDataImporter _generalRegionDataImporter;
        private readonly IDataImporter _worldRegionDataImporter;
        private readonly IDataImporter _gdpDataImporter;
        private readonly IXlsFormulaUpdaterService _xlsFormulaUpdaterService;
        private readonly ILogger _logger;
        private NxsDbContext _context { get; set; }
        private IXlsUploadRepository _xlsUploadRepository { get; set; }
        private IUnitOfWork _unitOfWork;



        public XlsImportVariableDataService(IXlsUploadRepository xlsUploadRepository,
                                            NxsDbContext context,
                                            IXlsFormulaUpdaterService xlsFormulaUpdaterService,
                                            GeneralRegionDataImporter generalRegionDataImporter,
                                            WorldRegionDataImporter worldRegionDataImporter,
                                            GdpDataImporter gdpDataImporter,
                                            IUnitOfWork unitOfWork,
                                            ILoggerFactory loggerFactory)
        {
            _xlsUploadRepository = xlsUploadRepository;
            _context = context;
            _xlsFormulaUpdaterService = xlsFormulaUpdaterService;
            _generalRegionDataImporter = generalRegionDataImporter;
            _worldRegionDataImporter = worldRegionDataImporter;
            _gdpDataImporter = gdpDataImporter;
            _generalRegionDataImporter.XlsImportVariableDataService = this;
            _worldRegionDataImporter.XlsImportVariableDataService = this;
            _gdpDataImporter.XlsImportVariableDataService = this;
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger("NXS.Services.Excel.DataImport.XlsImportVariableDataService");
        }


        public async Task Import()
        {
            if (string.IsNullOrEmpty(_workBookBasePath))
            {
                return;
            }

            var xlsUploads = await _xlsUploadRepository.GetXlsUploadsNotProcessdAsync();

            foreach (var xlsUpload in xlsUploads)
            {
                SetCurrentParameterIds(xlsUpload);

                // Open file
                var filePath = $"{_workBookBasePath}/{xlsUpload.FileName}";
                var fileInfo = new FileInfo(filePath);

                // Open Xls file
                using (var package = new ExcelPackage(fileInfo))
                {
                    CurrentWorkBook = package.Workbook;

                    UpdateXlsFormulas();
                    package.Save();

                    RemoveSubVAriableData();

                    // await _generalRegionDataImporter.RemoveDataAsync();
                    await _generalRegionDataImporter.ImportDataAsync();

                    // await _worldRegionDataImporter.RemoveDataAsync();
                    await _worldRegionDataImporter.ImportDataAsync();

                    // await _gdpDataImporter.RemoveDataAsync();
                    await _gdpDataImporter.ImportDataAsync();
                }

                xlsUpload.IsProcessed = true;
                _xlsUploadRepository.Update(xlsUpload);
                await _unitOfWork.CompleteAsync();

                // Remove File
                try
                {
                    fileInfo.Delete();
                    _logger.LogInformation($"File: {filePath} is deleted");
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"Error - Delete file: {filePath}");
                }

            }
        }


        public void SetWorkBookBasePath(string basePath)
        {
            _workBookBasePath = basePath;
        }


        private void SetCurrentParameterIds(XlsUpload xlsUpload)
        {
            CurrentScenarioId = xlsUpload.ScenarioId;
            CurrentKeyParameterId = xlsUpload.KeyParameterId;
            CurrentKeyParameterLevelId = xlsUpload.KeyParameterLevelId;
            CurrentParentRegionId = xlsUpload.ParentRegionId;
        }

        private void UpdateXlsFormulas()
        {
            _xlsFormulaUpdaterService.VariableDescriptions = XlsVariableDescriptions.AllDescriptions;
            _xlsFormulaUpdaterService.SetWorkbook(CurrentWorkBook);
            _xlsFormulaUpdaterService.Update();
        }

        private void RemoveSubVAriableData()
        {
            var query = _context.SubVariableData.Where(sv => sv.ParentRegionId == CurrentParentRegionId &&
                sv.ScenarioId == CurrentScenarioId &&
                sv.KeyParameterId == CurrentKeyParameterId &&
                sv.KeyParameterLevelId == CurrentKeyParameterLevelId).AsQueryable();

            _context.SubVariableData.RemoveRange(query);
            _context.SaveChanges();
        }
    }
}