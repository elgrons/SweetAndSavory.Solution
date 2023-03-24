using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "The customer field for the order cannot be left blank.")]
        public string Customer { get; set; }
        public List<OrderTreat> JoinOrderTreat { get;}
        public ApplicationUser User { get; set; } 
    }
}