using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class AssignPositionView
    {
        public int StaffID { get; set; }
        public string Staff { get; set; }
        public int PositionID { get; set; }
        public string Position { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public string Desc { get; set; }
        public string ActionBy { get; set; }
        public bool Status { get; set; }
    }
}
