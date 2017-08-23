using NXS.Extensions;

namespace NXS.Core
{
    public class VariableQuery : IQueryObject
    {
        public int? VariableGroupId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }        
        public bool? IsPaging { get; set; }
    }
}