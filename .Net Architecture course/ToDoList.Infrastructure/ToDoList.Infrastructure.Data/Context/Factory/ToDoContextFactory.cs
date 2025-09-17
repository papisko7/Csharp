using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace ToDoList.Infrastructure.Data.Context.Factory
{
    public class ToDoContextFactory : IDesignTimeDbContextFactory<ToDoContext>
    {
        public ToDoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<ToDoContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new ToDoContext(builder.Options);
        }
    }
}