using System;

namespace HanaSolution.Data.Infrastructure
{
    public interface IPartialtable
    {
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? ModifyDate { get; set; }
        string ModifyBy { get; set; }
        bool Status { get; set; }
    }
}
