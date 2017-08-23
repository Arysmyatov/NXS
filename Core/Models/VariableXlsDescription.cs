using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    // Description for Variables
    public class VariableXlsDescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int VariableId { get; set; }
        public string SheetName { get; set; }
        public int RowBg { get; set; }
        public int RowEnd { get; set; }

        [DefaultValue(0)]        
        public int RegionCol { get; set; }

        [DefaultValue(0)]
        public int ProcessSetCol { get; set; }

        [DefaultValue(0)]
        public int AttributeCol { get; set; }

        [DefaultValue(0)]
        public int UserConstraintCol { get; set; }

        [DefaultValue(0)]
        public int CommodityCol { get; set; }

        [DefaultValue(0)]
        public int CommoditySetCol { get; set; }

        [DefaultValue(0)]
        public int YearColBg { get; set; }

        [DefaultValue(0)]        
        public int YearColEnd { get; set; }
        
        public Variable Variable { get; set; }
    }
}