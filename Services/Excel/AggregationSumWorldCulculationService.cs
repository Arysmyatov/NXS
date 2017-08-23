using NXS.Core;
using NXS.Core.NxsConstants;
using NXS.Services.Abstract;

namespace NXS.Services.Excel
{
    public class AggregationSumWorldCulculationService : AggregationSumCulculationServiceAbstract
    {
        public AggregationSumWorldCulculationService(IVariableDataRepository variableDataRepository,
                                                ISubVariableDataRepository subVariableDataRepository,
                                                IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                                IUnitOfWork unitOfWork) : base(variableDataRepository, subVariableDataRepository, regionAgrigationTypeRepository, unitOfWork)
        {
            IsRegionIncluded = false;
            RegionType = RegionConstants.Types.World;
        }
    }
}