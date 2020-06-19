using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HanaSolution.Data.Models
{
    [Table("ProductFeedbacks")]
   public class ProductFeedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long Product { get; set; }
        public int Rate { get; set; }
        [MaxLength(850)]
        public string Comment { get; set; }
        public string Files { get; set; }
        public int Member { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
