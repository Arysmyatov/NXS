using NXS.Core;
using NXS.Core.NxsConstants;
using NXS.Services.Abstract;

namespace NXS.Services.Excel
{
    public class AggregationSumCulculationService : AggregationSumCulculationServiceAbstract
    {
        public AggregationSumCulculationService(IVariableDataRepository variableDataRepository,
                                                ISubVariableDataRepository subVariableDataRepository,
                                                IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                                IUnitOfWork unitOfWork) : base(variableDataRepository, subVariableDataRepository, regionAgrigationTypeRepository, unitOfWork)
        {
            IsRegionIncluded = true;
            RegionType = RegionConstants.Types.ByRegion;
        }
    }
}