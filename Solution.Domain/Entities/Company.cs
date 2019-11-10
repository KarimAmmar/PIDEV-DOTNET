using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Company_Name { get; set; }
        public string Company_Number { get; set; }
        public string Company_Address { get; set; }
        public string Company_Email { get; set; }

        public string Company_Description { get; set; }
        public string Company_Website { get; set; }
        public string Company_Logo { get; set; }
        public string NumberOfEmployees { get; set; }



        //prop de navig
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        // public virtual ICollection<Post> Posts { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

    }
}
