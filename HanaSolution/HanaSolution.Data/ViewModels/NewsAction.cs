using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class NewsAction
    {
        public long ID { get; set; }
        [MaxLength(250,ErrorMessage ="Chỉ có thể nhập tối đa 250 ký tự")]
        [Required(ErrorMessage ="Vui lòng nhập dữ liệu này")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string Desc { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public string Content { get; set; }
        public int ViewNumber { get; set; }
        [MaxLength(60, ErrorMessage = "Chỉ có thể nhập tối đa 60 ký tự")]
        public string MetaTitle { get; set; }
        [MaxLength(160, ErrorMessage = "Chỉ có thể nhập tối đa 160 ký tự")]
        public string MetaDesc { get; set; }
        [MaxLength(260, ErrorMessage = "Chỉ có thể nhập tối đa 260 ký tự")]
        public string MetaKeyword { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
        public bool Status { get; set; }
    }
}
