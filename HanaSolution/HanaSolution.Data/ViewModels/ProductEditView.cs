using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Data.ViewModels
{
   public class ProductEditView
    {
        public long ID { get; set; }
        [MaxLength(250, ErrorMessage = "Title can have a max of 250 characters")]
        [MinLength(5, ErrorMessage = "Title must have a minimum of 5 characters")]
        public string Title { get; set; }
        [MaxLength(350, ErrorMessage = "Description can have a max of 350 characters")]
        [MinLength(5, ErrorMessage = "Description must have a minimum of 5 characters")]
        public string Desc { get; set; }
        public string Content { get; set; }
        public int Staff { get; set; }
        public string Avatar { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
    }
}
