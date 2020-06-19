using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class OrderView
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// 0-Payment on delivery | 1-Online payment | 2-Bank transfer
        /// </summary>
        public int TypePayment { get; set; }
        /// <summary>
        /// 0-Not Pay | 1-Paid
        /// </summary>
        public int StatusPayment { get; set; }
        /// <summary>
        /// 0-Awaiting | 1-Processing | 2-Delivering | 3-Already delivered | 4-Staff cancel | 5-Customer cancel
        /// </summary>
        public int StatusOrder { get; set; }
        public int Member { get; set; }
        public int Receipt { get; set; }
        public string MemberName { get; set; }
        public double Amount { get; set; }
        public double Reduce { get; set; }
        public double Total { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
    public class OrderDetailView{
        public string Code { get; set; }
        public long Product { get; set; }
        public string ProductName { get; set; }
        public string ProductAvatar { get; set; }
        public double Price { get; set; }
        public double Reduce { get; set; }
        public int Qty { get; set; }
        public double Total { get; set; }
    }
}
