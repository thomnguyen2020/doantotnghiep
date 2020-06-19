using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class MemberReceiptInfoView
    {
        public int ID { get; set; }
        public int Member { get; set; }
        [MaxLength(250,ErrorMessage ="Chỉ có thể nhập tối đa 250 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string Phone { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        [Required(ErrorMessage ="Vui lòng nhập thông tin này")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string Address { get; set; }
    }
}
