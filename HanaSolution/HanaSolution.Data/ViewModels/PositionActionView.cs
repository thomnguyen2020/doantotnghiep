using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class PositionActionView
    {
        public int ID { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Title { get; set; }
        [MaxLength(550, ErrorMessage = "Chỉ có thể nhập tối đa 550 ký tự")]
        public string Desc { get; set; }
        public string ActionBy { get; set; }
        public bool Status { get; set; }
    }
}
