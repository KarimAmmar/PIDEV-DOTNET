using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }


        public int NbrLikes { get; set; }
        //foreign key 

        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }


    }
}
