  
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Factory.Models
{
  public class SneussFactoryContextFactory : IDesignTimeDbContextFactory<SneussFactoryContext>
  {
    SneussFactoryContext IDesignTimeDbContextFactory<SneussFactoryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
      .Build();

      var builder = new DbContextOptionsBuilder<SneussFactoryContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);
      
      return new SneussFactoryContext(builder.Options);
    }
  }
}