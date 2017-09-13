using System.Collections.Generic;

namespace NXS.Controllers.Resources
{
    public class DataResource
    {
        public int KeyParameterId { get; set; }
        public int KeyParameterLevelId { get; set; }
        public IEnumerable<string> Years { get; set; }
        public IEnumerable<string> SubVariables { get; set; }
        public List<decimal[]> Values { get; set; }
    }
}