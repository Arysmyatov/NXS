using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Core.NxsConstants;
using NXS.Services.Abstract;

namespace NXS.Services.Abstract
{
    public abstract class AggregationSumCulculationServiceAbstract : IAggregationSumCulculation
    {
        protected const byte PageSize = 200;
        internal readonly IVariableDataRepository _variableDataRepository;
        internal readonly ISubVariableDataRepository _subVariableDataRepository;
        internal readonly IRegionAgrigationTypeRepository _regionAgrigationTypeRepository;
        internal readonly IUnitOfWork _unitOfWork;
        protected bool IsRegionIncluded { get; set; }
        protected string RegionType { get; set; }

        public AggregationSumCulculationServiceAbstract(IVariableDataRepository variableDataRepository,
                                                ISubVariableDataRepository subVariableDataRepository,
                                                IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                                IUnitOfWork unitOfWork)
        {
            _variableDataRepository = variableDataRepository;
            _subVariableDataRepository = subVariableDataRepository;
            _regionAgrigationTypeRepository = regionAgrigationTypeRepository;
            _unitOfWork = unitOfWork;
            IsRegionIncluded = true;
            RegionType = RegionConstants.Types.ByRegion;
        }


        public virtual async Task UpdateSumsAsync()
        {
            var currentPage = 1;
            bool processing;
            var subVariableDataQuery = await GetSubVariableDataQuery();
            do
            {
                subVariableDataQuery.Page = currentPage;

                // Get Sub variables without GDP
                var subVariableData = await _subVariableDataRepository.GetSubVariableDataWithoutGdp(subVariableDataQuery);
                var subVariableDataArray = subVariableData.Items.Where(i => i.AttributeId != null ||
                                                                            i.CommodityId != null ||
                                                                            i.CommoditySetId != null ||
                                                                            i.ProcessSetId != null ||
                                                                            i.UserConstraintId != null
                                                                        ).ToArray();

                foreach (var dataItem in subVariableDataArray)
                {
                    var query = GetVariableDataQuery(dataItem);

                    var sum = await _variableDataRepository.GetSumAsync(query);
                    dataItem.Value = sum;
                    _subVariableDataRepository.Update(dataItem);
                }

                await _unitOfWork.CompleteAsync();
                currentPage++;
                processing = subVariableDataArray.Count() == PageSize;

            } while (processing);



        }


        protected VariableDataQuery GetVariableDataQuery(SubVariableData dataItem)
        {
            var variableDataQuery = new VariableDataQuery
            {
                ScenarioId = dataItem.ScenarioId,
                VariableId = dataItem.VariableId,
                KeyParameterId = dataItem.KeyParameterId,
                KeyParameterLevelId = dataItem.KeyParameterLevelId,
                ProcessSetId = dataItem.ProcessSetId,
                AttributeId = dataItem.AttributeId,
                CommodityId = dataItem.CommodityId,
                CommoditySetId = dataItem.CommoditySetId,
                UserConstraintId = dataItem.UserConstraintId,
                Year = dataItem.Year,
                IsPaging = false
            };

            if (IsRegionIncluded)
            {
                variableDataQuery.RegionId = dataItem.RegionId;
            }
            return variableDataQuery;
        }


        protected async Task<SubVariableDataQuery> GetSubVariableDataQuery()
        {
            var regionType = await _regionAgrigationTypeRepository.GetTypeAsync(RegionType);
            return new SubVariableDataQuery
            {
                IsPaging = true,
                PageSize = PageSize,
                RegionAgrigationTypeId = regionType.Id
            };
        }
    }
}