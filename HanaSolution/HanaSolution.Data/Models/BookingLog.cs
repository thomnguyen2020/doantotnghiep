using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.Models
{
    [Table("BookingLogs")]
    public class BookingLog
    {
        [Key]
        [Column(Order = 0)]
        public string TransactionID { get; set; }
        /// <summary>
        /// 0 Send Transaction | 1 Comfirm success | 2 Transaction cancel
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int Step { get; set; }
        public string Name { get; set; }
        public int Member { get; set; }
        public string PostJson { get; set; }
        public string PartnerResult { get; set; }
        public DateTime Date { get; set; }
    }
}
