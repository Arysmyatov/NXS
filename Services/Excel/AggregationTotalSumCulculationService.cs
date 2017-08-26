using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Core.NxsConstants;
using NXS.Services.Abstract;

namespace NXS.Services.Excel
{
    public class AggregationTotalSumCulculationService: IAggregationSumCulculation
    {
        protected const byte PageSize = 200;
        internal readonly IVariableDataRepository _variableDataRepository;
        internal readonly ISubVariableDataRepository _subVariableDataRepository;
        internal readonly IAgreegationSubVariableRepository _agreegationSubVariableRepository;
        internal readonly IRegionAgrigationTypeRepository _regionAgrigationTypeRepository;
        internal readonly IUnitOfWork _unitOfWork;
        protected bool IsRegionIncluded { get; set; }
        protected string RegionType { get; set; }

        public AggregationTotalSumCulculationService(ISubVariableDataRepository subVariableDataRepository,
                                                     IAgreegationSubVariableRepository agreegationSubVariableRepository,
                                                     IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                                     IUnitOfWork unitOfWork)
        {
            _subVariableDataRepository = subVariableDataRepository;
            _agreegationSubVariableRepository = agreegationSubVariableRepository;
            _unitOfWork = unitOfWork;
            IsRegionIncluded = true;
            RegionType = RegionConstants.Types.ByRegion;
        }
        

        public virtual async Task UpdateSumsAsync()
        {
            // Get All Total Sub variables
            var subVariablesTotal = _agreegationSubVariableRepository.GetAgreegationSubVariables().ToArray();

            foreach(var subVariableTotal in subVariablesTotal) {
                var query = await GetSubVariableDataQuery(subVariableTotal.VariableId);
                var subVariable = await _subVariableDataRepository.GetSubVariableDataWithoutGdp(query);

            }
        }


        protected async Task<SubVariableDataQuery> GetSubVariableDataQuery(int variableId)
        {
            var regionType = await _regionAgrigationTypeRepository.GetTypeAsync(RegionType);
            return new SubVariableDataQuery
            {
                IsPaging = false,
                RegionAgrigationTypeId = regionType.Id,
                VariableId = variableId
            };
        }
    }
}