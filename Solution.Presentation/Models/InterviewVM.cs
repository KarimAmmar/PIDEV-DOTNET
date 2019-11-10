using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public enum TypeVM { Unscheduled, Scheduled, Done }

    public class InterviewVM
    {
        public int InterviewId { get; set; }
        public int User_Id { get; set; }
        public int Candidat_Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Interview_Date { get; set; }

        public String Interview_Location { get; set; }
        public TypeVM Interview_Type { get; set; }

    }
}