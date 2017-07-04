using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NXS.Models
{
    public class KeyParameterGroupResource
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<KeyParameterResource> KeyParameters { get; set; }

        public KeyParameterGroupResource() {
            KeyParameters = new Collection<KeyParameterResource>();
        }
    }
}