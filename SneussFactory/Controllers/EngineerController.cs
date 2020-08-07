using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly SneussFactoryContext _db;
    public EngineerController(SneussFactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {

      return View();
    }
  }
}