using HanaSolution.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.Models
{
    [Table("AssignPositions")]
   public class AssignPosition : Partialtable
    {
        [Key,Column(Order =0)]
        public int StaffID { get; set; }
        [Key, Column(Order = 1)]
        public int PositionID { get; set; }
        [Key, Column(Order = 2)]
        public int DepartmentID { get; set; }
        public string Desc { get; set; }
    }
}
