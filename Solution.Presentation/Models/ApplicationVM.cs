using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ApplicationVM
    {
        public int ApplicationId { get; set; }
        public int Candidat_Id { get; set; }
        public int Job_Offer_Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Application_Date { get; set; }
        public String Application_Description { get; set; }
        public String Application_Status { get; set; }
    }
}