using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Models
{
    [Table("Regions")]    
    public class Region 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int ParentRegionId { get; set; }

        public ICollection<Data> Data { get; set; }

        public Region() {
            Data = new Collection<Data>();
        }        
    }
}