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
      return View(_db.Engineers.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer, int id)
    {
      _db.Add(engineer);
      if (id != 0)
      {
        _db.EngineerMachine.Add(new { EngineerId = engineer.EngineerId, MachineId = id});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}