using System;

namespace HanaSolution.Data.Infrastructure
{
    public class Partialtable : IPartialtable
    {
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public bool Status { get; set; }
    }
}
