using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Models
{
    [Table("KeyParameterGroups")]
    public class KeyParameterGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<KeyParameter> KeyParameters { get; set; }

        public KeyParameterGroup() {
            KeyParameters = new Collection<KeyParameter>();
        }
    }
}