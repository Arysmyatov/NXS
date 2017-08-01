using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("VariableData")]
    public class VariableData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int RegionId { get; set; }

        public int ProcessSetId { get; set; }

        public int AttributeId { get; set; }

        public int UserConstraintId { get; set; }

        public int CommoditySetId { get; set; }

        public Region Region { get; set; }

        public ProcessSet ProcessSet { get; set; }

        public Attribute Attribute { get; set; }

        public UserConstraint UserConstraint { get; set; }
        
        public CommoditySet CommoditySet { get; set; }

        public decimal Value { get; set; }
    }
}