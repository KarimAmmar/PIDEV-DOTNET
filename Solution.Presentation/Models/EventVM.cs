using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class EventVM
    {
        [Key]
        public int EventId { get; set; }
        [Display(Name = "Event Title")]
        [StringLength(100)]
        [Required]
        public string Event_Title { get; set; }
        [Display(Name = "Event Description")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Event_Description { get; set; }
        [Display(Name = "Event Address")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Event_Address { get; set; }
        [Display(Name = "Event Organiser")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Event_Organizer { get; set; }
        [Display(Name = "Date")]
        [Required]
        
        [DataType(DataType.Date)]
        public DateTime Event_Date { get; set; }

        //   private Address Event_Address { get; set; }
        public int NumberOfParticipent { get; set; }
        //prop nav
        [Display(Name = "Event Organizer")]
        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]

        public virtual Company Company { get; set; }
    }
}