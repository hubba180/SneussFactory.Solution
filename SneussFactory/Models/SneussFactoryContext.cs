using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class SneussFactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }

    public SneussFactoryContext(DbContextOptions options) : base(options) { }
  }
}