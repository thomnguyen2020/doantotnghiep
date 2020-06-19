using HanaSolution.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HanaSolution.Data.Models
{

    [Table("Departments")]
    public class Department : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(550)]
        public string Desc { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Mail { get; set; }
    }
}
