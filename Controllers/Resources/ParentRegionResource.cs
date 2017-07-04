using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NXS.Controllers.Resources
{
    public class ParentRegionResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RegionResource> Regions { get; set; }
        
        public ParentRegionResource() {
            Regions = new Collection<RegionResource>();
        }
    }
}