using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Availability
    {
        public int AvailabilityId { get; set; }
        public int Representator_Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Availability_Date_Begin { get; set; }
        [DataType(DataType.Date)]
        public DateTime Availability_Date_End { get; set; }

        [ForeignKey("Representator_Id")]
        public virtual User user { get; set; }
    }
}
