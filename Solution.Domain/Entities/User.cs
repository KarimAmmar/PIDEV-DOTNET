using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
  public  class User
    {
      
        public int UserId { get; set; }
      //  [Required(ErrorMessage = "this filed is required")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string username { get; set; }
      //  [Required(ErrorMessage = "this filed is required")]
        //[Range(8, 15)]
        public string password { get; set; }
        [Required(ErrorMessage = "this filed is required")]
        public  int status { get; set; }
        [Required(ErrorMessage = "this filed is required")]
        public string picture { get; set; }

        [Required(ErrorMessage = "this filed is required")]
 //       public Address Address { get; set; }

        public int role { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }

    }

}
