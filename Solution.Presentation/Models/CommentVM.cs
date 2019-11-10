using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Presentation.Models
{
    public class CommentVM
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }


        public string Content { get; set; }
        [DataType(DataType.Date)]

        public DateTime CommentDate { get; set; }


        public int NbrLikes { get; set; }
        //foreign key 
        public int? PostId { get; set; }
        
    }
}