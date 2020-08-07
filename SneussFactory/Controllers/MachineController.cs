using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    private readonly SneussFactoryContext _db;
    public MachineController(SneussFactoryContext db)
    {
      _db = db; 
    }
    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Add(machine);
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {MachineId = machine.MachineId, EngineerId = EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}