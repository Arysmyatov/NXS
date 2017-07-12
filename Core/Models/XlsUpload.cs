using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    public class XlsUpload
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        public int RegionId  { get; set; }
        public int KeyParameterLevelId  { get; set; }
        public int ScenarioId  { get; set; }
        public DateTime UploadDate { get; set; }
    }
}