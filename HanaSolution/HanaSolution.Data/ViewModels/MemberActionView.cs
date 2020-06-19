using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class MemberActionView
    {
        public int ID { get; set; }
        [MaxLength(150,ErrorMessage ="Bạn chỉ có thể nhập tối đa 150 ký tự")]
        public string Name { get; set; }
        [MaxLength(350, ErrorMessage = "Bạn chỉ có thể nhập tối đa 350 ký tự")]
        public string Address { get; set; }
        [MaxLength(50, ErrorMessage = "Bạn chỉ có thể nhập tối đa 50 ký tự")]
        public string Phone { get; set; }
        public int Gender { get; set; }
        [MaxLength(150, ErrorMessage = "Bạn chỉ có thể nhập tối đa 150 ký tự")]
        public string Mail { get; set; }
        [MaxLength(50, ErrorMessage = "Bạn chỉ có thể nhập tối đa 50 ký tự")]
        public string Account { get; set; }
        [MaxLength(50, ErrorMessage = "Bạn chỉ có thể nhập tối đa 50 ký tự")]
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
