using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("AgreegationSubVariables")]
    public class AgreegationSubVariable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int VariableId { get; set; }

        public Variable Variable { get; set; }

        public ICollection<AgreegationSubVariableSubVariable> AgreegationSubVariableSubVariables { get; set; }

        public AgreegationSubVariable(){
            AgreegationSubVariableSubVariables = new Collection<AgreegationSubVariableSubVariable>();
        }
    }
}