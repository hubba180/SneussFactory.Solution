using Microsoft.AspNetCore.Mvc;

namespace Factory.Controller
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