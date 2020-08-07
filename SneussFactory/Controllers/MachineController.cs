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
    public ActionResult Details(int id)
    {
      var ThisMachine = _db.Machines
        .Include(machine => machine.Engineers)
          .ThenInclude(join => join.Engineer)
        .FirstOrDefault(machine => machine.MachineId == id);
      return View(ThisMachine);
    }
    public ActionResult Edit(int id)
    {
      var ThisMachine = _db.Machines.FirstOrDefault(a => a.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(ThisMachine);
    }
    [HttpPost]
    public ActionResult Edit(Machine machine, int engineerId)
    {
      if (engineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(a => a.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(a => a.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddEngineer(int id)
    {
      var ThisMachine = _db.Machines.FirstOrDefault(a => a.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(ThisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {  EngineerId = EngineerId, MachineId = machine.MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}