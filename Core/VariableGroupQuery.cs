using System;
using NXS.Extensions;

namespace NXS.Core
{
    public class VariableGroupQuery : IQueryObject
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
        public bool? IsPaging { get; set; }        
    }
}