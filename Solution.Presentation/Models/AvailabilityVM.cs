using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class AvailabilityVM
    {
        public int AvailabilityId { get; set; }
        public int Representator_Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Availability_Date_Begin { get; set; }
        [DataType(DataType.Date)]
        public DateTime Availability_Date_End { get; set; }

    }
}