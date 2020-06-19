using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.Models
{
    [Table("Banners")]
   public class Banner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Avatar { get; set; }
        [MaxLength(250)]
        public string Desc { get; set; }
        public bool Status { get; set; }
    }
}
