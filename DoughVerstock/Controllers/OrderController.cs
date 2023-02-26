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
  [HttpGet("/vendors/{vendorid}/orders/new")]
  public ActionResult New(int vendorid)
  {
    Vendor foundVendor;
    try
    {
      foundVendor = Vendor.Database[vendorid];
      return View(foundVendor);
    }
    catch (KeyNotFoundException)
    {
      return View();
    }
  }
  [HttpPost("/vendors/{vendorid}/orders")]
  public ActionResult Create(string vendorid, string bread, string pastry, string croissant)
  {
    Order newOrder = new Order(int.Parse(vendorid));
    if (bread != "0")
    {
      newOrder.AddGood(new Bread(int.Parse(bread)));
    }
    if (pastry != "0")
    {
      newOrder.AddGood(new Pastry(int.Parse(pastry)));
    }
    if (croissant != "0")
    {
      newOrder.AddGood(new Croissant(int.Parse(croissant)));
    }
    return RedirectToPage("");
  }
}

