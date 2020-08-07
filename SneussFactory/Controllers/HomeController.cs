using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly SneussFactoryContext _db;
    // public HomeController(SneussFactoryContext db)
    // {
    //   _db = db;
    // }
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    // public ActionResult Lists()
    // {
    //   return View(_db)
    // }

  }
}