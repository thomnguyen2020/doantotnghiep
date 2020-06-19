using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class VoucherAddView
    {
        public long Promotion { get; set; }
        public string PromotionCode { get; set; }
        public int LimitNumber { get; set; }
        public int Type { get; set; }
        public bool IsApplyOrder { get; set; }
        public string Product { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập dữ liệu này")]
        public int AmountReduced { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public double PercentReduced { get; set; }
        public long Staff { get; set; }
    }
}
