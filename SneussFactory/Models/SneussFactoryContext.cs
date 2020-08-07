using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class SneussFactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachine { get; set; }

    public SneussFactoryContext(DbContextOptions options) : base(options) { }
  }
}