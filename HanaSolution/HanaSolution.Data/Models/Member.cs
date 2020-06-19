using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HanaSolution.Data.Models
{

    [Table("Members")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public int Gender { get; set; }
        [MaxLength(150)]
        public string Mail { get; set; }
        [MaxLength(50)]
        public string Account { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public DateTime DateJoin { get; set; }
        public string Platform { get; set; }
        public DateTime? BirthDay { get; set; }
        public double AccumulatedPoints { get; set; }
        public bool Status { get; set; }
    }
}
