using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class ProductCategoryAction
    {
        public int ID { get; set; }
        [MaxLength(250,ErrorMessage ="Chỉ có thể nhập tối đa 250 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public string Title { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        [Required(ErrorMessage ="Vui lòng nhập dữ liệu này")]
        public string Desc { get; set; }
        public int Rank { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public string Avatar { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public bool Status { get; set; }
    }
}
