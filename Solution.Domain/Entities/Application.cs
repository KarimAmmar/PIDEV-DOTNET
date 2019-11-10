using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Application
    {
        public int ApplicationId { get; set; }
        public int Candidat_Id { get; set; }
        public int Job_Offer_Id { get; set; }
        public DateTime Application_Date { get; set; }
        public String Application_Description { get; set; }
        public String Application_Status { get; set; }



    }
}
