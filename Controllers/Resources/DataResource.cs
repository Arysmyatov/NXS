using System.Collections.Generic;

namespace NXS.Controllers.Resources
{
    public class DataResource
    {
        public IEnumerable<string> Years { get; set; }
        public IEnumerable<string> SubVariables { get; set; }
        public List<decimal[]> Values { get; set; }
    }
}