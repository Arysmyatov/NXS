using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("SubVariableData")]
    public class SubVariableData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int ScenarioId { get; set; }

        public int KeyParameterId { get; set; }

        public int KeyParameterLevelId { get; set; }

        public int? ParentRegionId { get; set; }
        
        public int? RegionId { get; set; }

        public int VariableId { get; set; }

        public int SubVariableId { get; set; }        

        public int RegionAgrigationTypeId { get; set; }

        public int? ProcessSetId { get; set; }

        public int? AttributeId { get; set; }

        public int? UserConstraintId { get; set; }

        public int? CommodityId { get; set; }

        public int? CommoditySetId { get; set; }

        public Scenario Scenario { get; set; }

        public KeyParameter KeyParameter { get; set; }

        public KeyParameterLevel KeyParameterLevel { get; set; }

        public Variable Variable { get; set; }
        
        public SubVariable SubVariable { get; set; }

        public RegionAgrigationType RegionAgrigationType { get; set; }

        public Region Region { get; set; }

        public ParentRegion ParentRegion { get; set; }        
        
        public ProcessSet ProcessSet { get; set; }

        public Attribute Attribute { get; set; }

        public UserConstraint UserConstraint { get; set; }

        public CommoditySet CommoditySet { get; set; }

        public string Year { get; set; }

        public decimal Value { get; set; }
    }
}