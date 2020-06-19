using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class PromotionView
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Exp:1|2|3|4  : 1 Is Limited the number of participants | 2 Limited Age | 3 Limited Gender | 4 Limited Member Level | 5 Limited Member Point 
        /// </summary>
        public string Type { get; set; }
    }
}
