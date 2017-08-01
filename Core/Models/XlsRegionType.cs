using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("XlsRegionTypes")]
    public class XlsRegionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VariableXls> VariableXls { get; set; }

        public XlsRegionType() {
            VariableXls = new Collection<VariableXls>();
        }
    }
}