using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("AgreegationSubVariableSubVariables")]
    public class AgreegationSubVariableSubVariable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int AgreegationSubVariableId { get; set; }

        public AgreegationSubVariable AgreegationSubVariable { get; set; }
    }
}