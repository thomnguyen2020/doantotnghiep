using HanaSolution.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HanaSolution.Data.Models
{
    [Table("Products")]
   public class Product : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string Desc { get; set; }
        public string Content { get; set; }
        public int Staff { get; set; }
        public string Avatar { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public double Rate { get; set; }
    }
}
