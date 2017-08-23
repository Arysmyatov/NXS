using NXS.Extensions;

namespace NXS.Core
{
    public class VariableDataQuery : IQueryObject
    {
        public int? VariableId { get; set; }
        public string Year { get; set; }
        public int? ScenarioId { get; set; }
        public int? ProcessSetId { get; set; }
        public int? RegionId { get; set; }
        public int? KeyParameterLevelId { get; set; }
        public int? KeyParameterId { get; set; }
        public int? AttributeId { get; set; }
        public int? CommodityId { get; set; }
        public int? CommoditySetId { get; set; }
        public int? UserConstraintId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public bool? IsPaging { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}