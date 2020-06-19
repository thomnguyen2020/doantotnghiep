using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class ContractView
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Vui lòng không để trống dữ liệu này")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống dữ liệu này")]
        public string FileScan { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
    }
}
