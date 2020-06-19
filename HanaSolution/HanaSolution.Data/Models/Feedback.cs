using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HanaSolution.Data.Models
{

    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(550)]
        public string Comment { get; set; }
        public int Member { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
    }
}
