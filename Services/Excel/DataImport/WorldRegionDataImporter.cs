using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
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
            base.ByRegionWorkSheetName = "Global Results";
            base.RegionAggregationTypeName = "World";

            _worldRegionName = RegionConstants.WorldRegionName;
        }


        public override async Task ImportDataAsync()
        {
            await SetCurrentRegionAgrigationTypeId();
            //await SetCurrentRegionIdAsync(_worldRegionName);
            CurrentRegionId = null;
            SetCurrentWorkSheet(ByRegionWorkSheetName);

            await ImportDataByVariableDescriptionsAsync();
        }


        public override async Task RemoveDataAsync()
        {
            var queryObj = new SubVariableDataQuery
            {
                ParentRegionId = XlsImportVariableDataService.CurrentParentRegionId,
                RegionId = null,
                KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId,
                VariableId = CurrenVariableId
            };
            _subVariableDataRepository.RemoveWorld(queryObj);
            await _unitOfWork.CompleteAsync();
        }

        protected override IVariableDescription[] GetVariableDescriptions() {
            return WorldVariableDescriptions.GetAllDescriptions();
        }

    }
}