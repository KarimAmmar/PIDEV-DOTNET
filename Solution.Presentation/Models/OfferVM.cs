using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Models
{
    public class OfferVM
    {
        [Key]
        public int OfferId { get; set; }


        [Display(Name = "Offer Title")]
        [StringLength(100)]
        [Required]

        public string Offer_Title { get; set; }


        [Display(Name = "Offer Description")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Offer_description { get; set; }



        //[Display(Name = "Company")]
        //public string Offre_Location { get; set; }

        //[Range(typeof(DateTime), "1/1/1966", "1/1/2020")]
        [Display(Name = "Duration")]
        public string Offre_Duration { get; set; }


        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]

        public float Offre_Salary { get; set; }


        public enum ContractTypeVM { Full_Time, Part_Time, Commission, Temporary, Internship, Contract }
        public enum OfferLevelVM { Entry_Level, Mid_Level, Senior_Level }


        [Display(Name = "Contract type")]

        public ContractTypeVM Offer_Contract_Type { get; set; }


        [Display(Name = "Level of expertise required")]

        public OfferLevelVM Offer_Level_Of_Expertise { get; set; }



        public DateTime Offer_DatePublished { get; set; }



        public int Vues { get; set; }



        [Display(Name = "Company")]

        public int? CompanyId { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }//liste à partir de la base

        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Levels { get; set; }



    }
}