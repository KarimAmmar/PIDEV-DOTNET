using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Content { get; set; }
        public string UrlImage { get; set; }
        public string UrlVideo { get; set; }

        public DateTime PostDate { get; set; }


        public int NbrLikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
