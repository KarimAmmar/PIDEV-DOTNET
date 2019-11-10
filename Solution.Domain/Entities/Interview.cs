using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public enum TypeInt { Unscheduled, Scheduled, Done }
   public class Interview
    {
        public int InterviewId { get; set; }
        public int User_Id { get; set; }
        public int Candidat_Id { get; set; }
        public DateTime Interview_Date { get; set; }
        
        public String Interview_Location { get; set; }
        public TypeInt Interview_Type { get; set; }

        [ForeignKey("Candidat_Id")]
        public virtual Candidate candidate { get; set; }
        [ForeignKey("User_Id")]
        public virtual User user { get; set; }



    }
}
