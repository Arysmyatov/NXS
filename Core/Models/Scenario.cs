using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NXS.Core.Models
{
    [Table("Scenarios")]
    public class Scenario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Data> Data { get; set; }

        public ICollection<XlsUpload> XlsUploads { get; set; }        

        public Scenario() {
            Data = new Collection<Data>();
            XlsUploads = new Collection<XlsUpload>();
        }     
    }
}