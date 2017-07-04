using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NXS.Controllers.Resources
{
    public class VariableGroupResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VariableResource> Variables { get; set; }
        
        public VariableGroupResource() {
            Variables = new Collection<VariableResource>();
        }
    }
}