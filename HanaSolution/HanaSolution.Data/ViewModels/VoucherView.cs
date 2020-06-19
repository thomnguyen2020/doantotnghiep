using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class VoucherView
    {
        public string Code { get; set; }
        /// <summary>
        /// 0 Reduced for amount of money | 1 Reduced for percent
        /// </summary>
        public int Type { get; set; }
        public bool IsApplyOrder { get; set; }
        public string Product { get; set; }
        public int AmountReduced { get; set; }
        public double PercentReduced { get; set; }
        public DateTime? DateUsed { get; set; }
        public bool IsUsed { get; set; }
    }
}
