using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.Models
{
    [Table("Orders")]
   public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(250)]
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
        public double Amount { get; set; }
        public double Reduce { get; set; }
        public double Total { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
