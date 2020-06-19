using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class Cart
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double Total { get; set; }

    }
    public class ListCart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public double Discount { get; set; }
        public double TotalAmount { get; set; }
        public List<Cart> Carts { get; set; }
    }

    public class CartUpdateResult
    {
        public string Status { get; set; }
        public string Amount { get; set; }
        public int Qty { get; set; }
        public string TotalAmount { get; set; }
    }


}
