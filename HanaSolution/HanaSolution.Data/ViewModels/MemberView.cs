using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class MemberView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string Mail { get; set; }
        public string Account { get; set; }
        public DateTime DateJoin { get; set; }
        public string Platform { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Status { get; set; }
        public double AccumulatedPoints { get; set; }
        public string Level { get; set; }
    }
}
