using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    public class Data
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public int ScenarioId { get; set; }
        [Required]
        public int KeyParameterId { get; set; }        
        [Required]
        public int KeyParameterLevelId { get; set; }
        [Required]
        public int VariableId { get; set; }
        [Required]
        public int SubVariableId { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public Region Region { get; set; }
        public Scenario Scenario { get; set; }
        public KeyParameter KeyParameter { get; set; }
        public KeyParameterLevel KeyParameterLevel { get; set; }
        public Variable Variable { get; set; }
        public SubVariable SubVariable { get; set; }
        public decimal Value { get; set; }
    }
}