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

        public int ScenarioId { get; set; }        

        public int KeyParameterId { get; set; }        

        public int KeyParameterLevelId { get; set; }        

        public int VariableId { get; set; }        

        public int? RegionId { get; set; }

        public int? ProcessSetId { get; set; }

        public int? AttributeId { get; set; }

        public int? UserConstraintId { get; set; }

        public int? CommodityId { get; set; }

        public int? CommoditySetId { get; set; }

        public Scenario Scenario { get; set; }

        public KeyParameter KeyParameter { get; set; }

        public KeyParameterLevel KeyParameterLevel { get; set; }

        public Variable Variable { get; set; }

        public Region Region { get; set; }

        public ProcessSet ProcessSet { get; set; }

        public Attribute Attribute { get; set; }

        public UserConstraint UserConstraint { get; set; }
        
        public CommoditySet CommoditySet { get; set; }

        public string Year { get; set; }

        public decimal Value { get; set; }
    }
}