using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class ProductViewList
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Avatar { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Staff { get; set; }
        public int StaffID { get; set; }
        public double Rate { get; set; }
        public string Content { get; set; }
    }
}
