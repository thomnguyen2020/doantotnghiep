using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {

        /// <summary>
        /// Order Code
        /// </summary>
        [Key, Column(Order = 0)]
        [MaxLength(250)]
        public string Code { get; set; }
        [Key, Column(Order = 1)]
        public long Product { get; set; }
        public double Price { get; set; }
        public double Reduce { get; set; }
        public int Qty { get; set; }
        public double Total { get; set; }
    }
}
