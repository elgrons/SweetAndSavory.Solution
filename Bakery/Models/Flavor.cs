using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Flavor
    {
        public int FlavorId { get; set; }
        [Required(ErrorMessage = "The type of flavor cannot be left blank.")]
        public string Type { get; set; }
        public List<FlavorTreat> JoinFlavorTreat { get;}
        public ApplicationUser User { get; set; } 
    }
}