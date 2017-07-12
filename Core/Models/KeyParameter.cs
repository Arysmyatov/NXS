using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("KeyParameters")]
    public class KeyParameter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int KeyParameterGroupId { get; set; }

        public ICollection<Data> Data { get; set; }

        public KeyParameter() {
            Data = new Collection<Data>();
        }           
    }
}