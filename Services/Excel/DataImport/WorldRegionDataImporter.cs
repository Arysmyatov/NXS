using System.Threading.Tasks;
using AutoMapper;
using NXS.Core;
using NXS.Core.NxsConstants;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion;

namespace NXS.Services.Excel.DataImport
{
    public class WorldRegionDataImporter : RegionDataImporterAbstarct
    {

        private readonly string _worldRegionName;

        public WorldRegionDataImporter(IRegionRepository regionRepository,
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
            base.ByRegionWorkSheetName = "Global Results";
            base.RegionAggregationTypeName = "World";

            _worldRegionName = RegionConstants.WorldRegionName;
        }


        public override async Task ImportDataAsync()
        {
            await SetCurrentRegionAgrigationTypeId();    
            await SetCurrentRegionIdAsync(_worldRegionName);
            SetCurrentWorkSheet(ByRegionWorkSheetName);

            await ImportDataByVariableDescriptionsAsync();
        }


        public override async Task RemoveDataAsync()
        {
            var queryObj = new SubVariableDataQuery
            {
                ScenarioId = XlsImportVariableDataService.CurrentScenarioId,
                KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId
            };
            _subVariableDataRepository.RemoveWorld(queryObj);
            await _unitOfWork.CompleteAsync();
        }

        protected override IVariableDescription[] GetVariableDescriptions() {
            return WorldVariableDescriptions.GetAllDescriptions();
        }

    }
}