using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Bakery.Models;
using System.Linq;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
      private readonly BakeryContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public HomeController(UserManager<ApplicationUser> userManager, BakeryContext db)
      {
        _userManager = userManager;
        _db = db;
      }
      
    [HttpGet("/")]
    public async Task<ActionResult> Index()
    {
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser != null)
      {
        Treat[] treats = _db.Treats
                        .Where(entry => entry.User.Id == currentUser.Id)
                        .ToArray();
        model.Add("treats", treats);
        Flavor[] flavors = _db.Flavors
                        .Where(entry => entry.User.Id == currentUser.Id)
                        .ToArray();
        model.Add("flavors", flavors);
        Order[] orders = _db.Orders
                        .Where(entry => entry.User.Id == currentUser.Id)
                        .ToArray();
        model.Add("orders", orders);
      }
      return View(model);
    }
  }
}