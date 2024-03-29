﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Certification
    {
        public int CertificationId { get; set; }
        public string Designation { get; set; }
        public DateTime DateObtained { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CredentialIdentification { get; set; }
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }



    }
}
