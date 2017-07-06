using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Models
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
        public int VariableId { get; set; }
        [Required]
        public int KeyParameterId { get; set; }
        [Required]
        public int KeyParameterLevelId { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}