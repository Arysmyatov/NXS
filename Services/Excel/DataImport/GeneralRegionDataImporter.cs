using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public GeneralRegionDataImporter(IRegionRepository regionRepository,
                                         IVariableRepository variableRepository,
                                         ISubVariableRepository subVariableRepository,
                                         ISubVariableDataRepository subVariableDataRepository,
                                         IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                         IMapper mapper,
                                         IUnitOfWork unitOfWork): base(
                                                        regionRepository,
                                                        variableRepository,
                                                        subVariableRepository,
                                                        subVariableDataRepository,
                                                        regionAgrigationTypeRepository,
                                                        mapper,
                                                        unitOfWork)
        {
            base.ByRegionWorkSheetName = "By region";
            base.RegionAggregationTypeName = "By Region";
        }


        public override async Task ImportDataAsync()
        {
            await SetCurrentRegionAgrigationTypeId();
            var regions = getRegionsEur();
            foreach (var regionName in regions)
            {
                await SetCurrentRegionIdAsync(regionName);
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
                ScenarioId = XlsImportVariableDataService.CurrentScenarioId,
                KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId
            };
            _subVariableDataRepository.RemoveGeneral(queryObj);
            await _unitOfWork.CompleteAsync();
        }


        #region Private methods

        protected override IVariableDescription[] GetVariableDescriptions() {
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