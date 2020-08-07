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
    public ActionResult Create(Engineer Engineer, int MachineId)
    {
      _db.Add(Engineer);
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = Engineer.EngineerId, MachineId = MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var ThisEngineer = _db.Engineers
        .Include(engineer => engineer.Machines)
          .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(ThisEngineer);
    }
    public ActionResult Edit(int id)
    {
      var ThisEngineer = _db.Engineers.FirstOrDefault(a => a.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(ThisEngineer);
    }
    [HttpPost]
    public ActionResult Edit(Engineer engineer, int machineId)
    {
      if (machineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var ThisEngineer = _db.Engineers.FirstOrDefault(a => a.EngineerId == id);
      return View(ThisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var ThisEngineer = _db.Engineers.FirstOrDefault(a => a.EngineerId == id);
      _db.Engineers.Remove(ThisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddMachine(int id)
    {
      var ThisEngineer = _db.Engineers.FirstOrDefault(a => a.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(ThisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {  MachineId = MachineId, EngineerId = engineer.EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}