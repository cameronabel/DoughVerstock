using Microsoft.AspNetCore.Mvc;
using DoughVerstock.Models;

namespace DoughVerstock.Controllers;

public class OrderController : Controller
{
  [HttpGet("/vendors/{vendorid}/orders")]
  public ActionResult Index(int vendorid)
  {
    try
    {
      Vendor foundVendor = Vendor.Database[vendorid];
      return View(foundVendor);
    }
    catch (KeyNotFoundException)
    {
      return View();
    }
  }
  [HttpGet("/vendors/{vendorid}/orders/{id}")]
  public ActionResult Show(int vendorid, int id)
  {
    Vendor foundVendor;
    try
    {
      foundVendor = Vendor.Database[vendorid];
    }
    catch (KeyNotFoundException)
    {
      return View();
    }
    foreach (Order order in foundVendor.Orders)
    {
      if (order.ID == id)
      {
        return View(order);
      }
    }
    return View();
  }

}

