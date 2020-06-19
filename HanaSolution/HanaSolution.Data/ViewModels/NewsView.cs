using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
    public class NewsView
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public int ViewNumber { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKeyword { get; set; }
    }
}
