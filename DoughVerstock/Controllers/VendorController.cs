using Microsoft.AspNetCore.Mvc;
using DoughVerstock.Models;

namespace DoughVerstock.Controllers;

public class VendorController : Controller
{

  [HttpGet("/vendors")]
  public ActionResult Index()
  {
    Console.WriteLine(1);
    Console.WriteLine(Vendor.Database.Count);
    return View(Vendor.Database);
  }

  [HttpGet("/vendors/new")]
  public ActionResult New()
  {
    return View();
  }
  [HttpPost("/vendors")]
  public ActionResult Create(string name, string description)
  {
    new Vendor(name, description);
    return RedirectToAction("Index");
  }
  [HttpGet("/vendors/{id}")]
  public ActionResult Show(int id)
  {
    try
    {
      Vendor foundVendor = Vendor.Database[id];
      return View(foundVendor);
    }
    catch (KeyNotFoundException)
    {
      return View();
    }

  }
}

