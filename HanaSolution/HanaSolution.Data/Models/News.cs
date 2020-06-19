using HanaSolution.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.Models
{
    [Table("News")]
   public class News : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public string Avatar { get; set; }
        [MaxLength(350)]
        public string Desc { get; set; }
        public string Content { get; set; }
        public int ViewNumber { get; set; }
        [MaxLength(60)]
        public string MetaTitle { get; set; }
        [MaxLength(160)]
        public string MetaDesc { get; set; }
        [MaxLength(260)]
        public string MetaKeyword { get; set; }
    }
}
