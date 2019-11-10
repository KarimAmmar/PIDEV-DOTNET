using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class PostVM
    {
        public int PostId { get; set; }
        public int UserId { get; set; }

        public string Content { get; set; }
        public string UrlImage { get; set; }
        public string UrlVideo { get; set; }
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }


        public int NbrLikes { get; set; }
        public virtual ICollection<CommentVM> Comments { get; set; }
    }
}