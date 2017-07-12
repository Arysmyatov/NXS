using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("Variables")]
    public class Variable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int VariableGroupId { get; set; }

        public ICollection<Data> Data { get; set; }

        public VariableXls VariableXls { get; set; }

        public Variable() {
            Data = new Collection<Data>();
            VariableXls = new VariableXls();
        }
    }
}