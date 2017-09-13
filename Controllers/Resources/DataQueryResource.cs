using System.Collections.Generic;
using NXS.Core.Models;

namespace NXS.Controllers.Resources
{
    public class DataQueryResource
    {
        public int? RegionId { get; set; }
        public int? ScenarioId { get; set; }
        public int? VariableId { get; set; }
        public IEnumerable<KeyParameterResource> KeyParameterResources { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}