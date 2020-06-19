using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class ResponseStaffLogin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string Mail { get; set; }
    }
}
