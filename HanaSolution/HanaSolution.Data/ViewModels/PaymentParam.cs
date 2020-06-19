using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class PaymentParam
    {
        public int ReceiptID { get; set; }
        public int TypePay { get; set; }
    }
    public class PaymentResult
    {
        public int Status { get; set; }
        public string Uri { get; set; }
    }
}
