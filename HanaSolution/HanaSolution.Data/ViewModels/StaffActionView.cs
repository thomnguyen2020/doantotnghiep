using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class StaffActionView
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        [MaxLength(150,ErrorMessage ="Chỉ có thể nhập tối đa 150 ký tự")]
        public string Name { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        public string Phone { get; set; }
        public int Gender { get; set; }
        [MaxLength(150, ErrorMessage = "Chỉ có thể nhập tối đa 150 ký tự")]
        public string Mail { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public string Account { get; set; }
        public string CreateBy { get; set; }
        public bool Status { get; set; }
    }
}
