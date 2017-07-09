using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Models
{
    public class VariableXls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        public string SheetName { get; set; }
        public int YearBgRow { get; set; }
        public int YearBgCol { get; set; }
        public int YearEndRow { get; set; }
        public int YearEndCol { get; set; }
        public int DataBgRow { get; set; }
        public int DataBgCol { get; set; }
        public int DataEndRow { get; set; }
        public int DataEndCol { get; set; }
        public int VariableId { get; set; }
    }
}