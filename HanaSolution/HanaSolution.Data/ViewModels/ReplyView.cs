using System;
using System.ComponentModel.DataAnnotations;

namespace HanaSolution.Data.ViewModels
{
    public class ReplyView
    {
        public long Feedback { get; set; }
        [MaxLength(350, ErrorMessage = "Comment can have a max of 350 characters")]
        [MinLength(5, ErrorMessage = "Comment must have a minimum of 5 characters")]
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
