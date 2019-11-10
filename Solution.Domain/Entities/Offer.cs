using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Offer_Title { get; set; }
        public string Offer_description { get; set; }

        public string Offre_Location { get; set; }
        public string Offre_Duration { get; set; }
        public float Offre_Salary { get; set; }
        public enum ContractType { Full_Time, Part_Time, Commission, Temporary, Internship, Contract }
        public ContractType Offer_Contract_Type { get; set; }
        //public string Offer_Contract_Type { get; set; }
        public enum OfferLevel { Entry_Level, Mid_Level, Senior_Level }
        public OfferLevel Offer_Level_Of_Expertise { get; set; }

        public DateTime Offer_DatePublished { get; set; }

        //public Boolean Validity { get; set; }
        public int Vues { get; set; }

        public int? CompanyId { get; set; }

        //public virtual ICollection<Candidate> Candidates { get; set; }
        [ForeignKey("CompanyId")]

        public virtual Company Company { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

    }
}
