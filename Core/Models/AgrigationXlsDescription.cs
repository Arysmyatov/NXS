using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("AgrigationXlsDescriptions")]    
    public class AgrigationXlsDescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int VariableId { get; set; }
        public int RegionAgrigationTypeId { get; set; }
        public string SheetName { get; set; }
        public int RowBg { get; set; }
        public int RowEnd { get; set; }
        public int YearRowBg { get; set; }
        public int YearColBg { get; set; }
        public int YearColEnd { get; set; }

        [DefaultValue(0)]
        public int SubVariableCol { get; set; }        
        
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

        public Variable Variable { get; set; }        

        public RegionAgrigationType RegionAgrigationType { get; set; }                
    }
}