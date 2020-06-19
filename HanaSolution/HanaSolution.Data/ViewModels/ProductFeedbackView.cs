using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class ProductFeedbackView
    {
        public long ID { get; set; }
        public string Product { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public string Files { get; set; }
        public string Member { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

    }
}
