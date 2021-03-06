using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public System.DateTime HireDate { get; set; }
    public string Notes { get; set; }
    public ICollection<EngineerMachine> Machines { get; set; }
  }
}