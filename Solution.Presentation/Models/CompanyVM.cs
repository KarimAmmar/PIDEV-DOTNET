using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class CompanyVM
    {
        [Key]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        [StringLength(100)]
        [Required]


        public string Company_Name { get; set; }

        [Display(Name = "Company Number")]
        [DataType(DataType.PhoneNumber)]


        public string Company_Number { get; set; }

        [DisplayName("Company Address")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Company_Address { get; set; }


        [DisplayName("Company E-mail")]
        [EmailAddress]
        public string Company_Email { get; set; }


        [DisplayName("Company Description")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Company_Description { get; set; }


        [DisplayName("Company WebSite")]
        [DataType(DataType.Url)]
        public string Company_Website { get; set; }


        [DisplayName("Company Logo")]
        public string Company_Logo { get; set; }


        [DisplayName("Number of employees")]
        public string NumberOfEmployees { get; set; }

    }
}