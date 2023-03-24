using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace Bakery.Controllers
{
  [Authorize]
  public class OrdersController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrdersController(UserManager<ApplicationUser> userManager, BakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Order> model = _db.Orders.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Order order)
    {
      if (!ModelState.IsValid)
      {
        return View(order);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        order.User = currentUser;
        _db.Orders.Add(order);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
    public ActionResult Details(int id)
    {
      Order thisOrder = _db.Orders
            .Include(order => order.JoinOrderTreat)
            .ThenInclude(join => join.Treat)
            .FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    public ActionResult Edit(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(orders => orders.OrderId == id);
      return View(thisOrder);
    }

    [HttpPost]
    public ActionResult Edit(Order order)
    {  
        if (!ModelState.IsValid)
      {
        return View(order);
      }
        else 
      {
      _db.Orders.Update(order);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }

    public ActionResult Delete(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      _db.Orders.Remove(thisOrder);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(orders => orders.OrderId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Kind");
      return View(thisOrder);
    }

    [HttpPost]
    public ActionResult AddTreat(Order order, int treatId)
    {
      #nullable enable
      OrderTreat? joinEntity = _db.OrderTreats.FirstOrDefault(join => (join.TreatId == treatId && join.OrderId == order.OrderId));
      #nullable disable
      if (joinEntity == null && treatId != 0)
      {
        _db.OrderTreats.Add(new OrderTreat() { TreatId = treatId, OrderId = order.OrderId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = order.OrderId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      OrderTreat joinEntry = _db.OrderTreats.FirstOrDefault(entry => entry.OrderTreatId == joinId);
      _db.OrderTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Search")]
    public ActionResult Search(string search)
    {
      List<Order> model = _db.Orders.Where(order => order.Customer.ToLower()
                              .Contains(search.ToLower())).ToList();
      return View(model);
    }
  }
}