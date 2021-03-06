using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.DataImport.VariableDescriptions.General;
using OfficeOpenXml;

namespace NXS.Services.Excel.DataImport
{
    public class GeneralRegionDataImporter : RegionDataImporterAbstarct
    {
        public const string RegionsSheetName = "General parameters";
        public const int RegionsRowBg = 3;
        public const int RegionsColBg = 2;

        public GeneralRegionDataImporter(IRegionRepository regionRepository,
                                         IVariableRepository variableRepository,
                                         ISubVariableRepository subVariableRepository,
                                         ISubVariableDataRepository subVariableDataRepository,
                                         IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                         IMapper mapper,
                                         IUnitOfWork unitOfWork,
                                         ILoggerFactory loggerFactory) : base(
                                                        regionRepository,
                                                        variableRepository,
                                                        subVariableRepository,
                                                        subVariableDataRepository,
                                                        regionAgrigationTypeRepository,
                                                        mapper,
                                                        unitOfWork,
                                                        loggerFactory)
        {
            base.ByRegionWorkSheetName = "By region";
            base.RegionAggregationTypeName = "By Region";
        }


        public override async Task ImportDataAsync()
        {
            await SetCurrentRegionAgrigationTypeId();
            var regions = getRegions();

            foreach (var regionName in regions)
            {
                await SetCurrentRegionIdAsync(regionName);
                await RemoveDataAsync();

                SetCurrentWorkSheet(ByRegionWorkSheetName);
                SetRegionInXls(regionName);
                RecalculateXlsResults();

                await ImportDataByVariableDescriptionsAsync();
            }
        }


        public override async Task RemoveDataAsync()
        {
            var queryObj = new SubVariableDataQuery
            {
                RegionId = CurrentRegionId,
                ScenarioId = XlsImportVariableDataService.CurrentScenarioId,
                KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId
            };
            _subVariableDataRepository.RemoveGeneral(queryObj);
            await _unitOfWork.CompleteAsync();
        }


        #region Private methods

        protected override IVariableDescription[] GetVariableDescriptions()
        {
            return GeneralVariableDescriptions.GetAllDescriptions();
        }

        private void RecalculateXlsResults()
        {
            CurrentWorkSheet.Calculate();
        }

        private void SetRegionInXls(string regionName)
        {
            CurrentWorkSheet.Cells[1, 2].Value = regionName;
        }

        private IEnumerable<string> getRegions()
        {
            SetCurrentWorkSheet(RegionsSheetName);

            var row = RegionsRowBg;
            var regions = new List<string>();
            
            var currentRegion = string.Empty;

            do
            {
                var regionCellVal = CurrentWorkSheet.Cells[row, RegionsColBg].Value;
                if (regionCellVal == null)
                {
                    break;
                }

                currentRegion = regionCellVal.ToString();
                if (string.IsNullOrEmpty(currentRegion) || currentRegion == "World")
                {
                    break;
                }
                regions.Add(currentRegion);
                row++;
            } while (true);

            return regions.ToArray();
        }



        // private async Task<IEnumerable<string>> getRegions()
        // {
        //     var regionQuery = new RegionQuery{
        //         ParentRegionId = XlsImportVariableDataService.CurrentParentRegionId
        //     };
        //     var regions = await _regionRepository.GetRegionsAsync(regionQuery);
        //     if(regions == null || regions.TotalItems == 0) {
        //         return new string[0];
        //     }
        //     return regions.Items.Select(r => r.Name);
        // }


        private IEnumerable<string> getRegionsEur()
        {
            return new string[] {
                "BNL",
                "DEU",
                "EEN",
                "EES",
                "FRA",
                "IAM",
                "IBE",
                "SDF",
                "UKI",
                "SWZ",
                "NOI"
            };
        }


        private IEnumerable<string> getRegionsMexico()
        {
            return new string[] {
                "CTR",
                "NES",
                "NOE",
                "OCC",
                "SSE"
            };
        }

        #endregion Private methods

    }
}