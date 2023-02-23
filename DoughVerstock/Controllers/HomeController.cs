using Microsoft.AspNetCore.Mvc;

namespace DoughVerstock.Controllers

{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
