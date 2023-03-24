using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Treat
    {
        public int TreatId { get; set; }
        [Required(ErrorMessage = "The kind of treat cannot be left blank.")]
        public string Kind { get; set; }
        public List<FlavorTreat> JoinFlavorTreat { get;}
        public ApplicationUser User { get; set; } 
    }
}