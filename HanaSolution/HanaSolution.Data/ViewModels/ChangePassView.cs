using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class ChangePassView
    {
        public string Account { get; set; }
        public string OldPass { get; set; }
        [MaxLength(15,ErrorMessage ="Độ dài tối đa của mật khẩu là 15 ký tự")]
        public string NewPass { get; set; }
        [MaxLength(15, ErrorMessage = "Độ dài tối đa của mật khẩu là 15 ký tự")]
        public string ConfirmPass { get; set; }
    }
}
