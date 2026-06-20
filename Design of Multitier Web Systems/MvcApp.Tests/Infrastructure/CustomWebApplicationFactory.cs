using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcApp.Tests.Infrastructure;

public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureServices(services =>
		{
			var descriptor = services.SingleOrDefault(
				d => d.ServiceType == typeof(DbContextOptions<StudentDbContext>));

			if (descriptor != null)
			{
				services.Remove(descriptor);
			}

			services.AddDbContext<StudentDbContext>(options =>
			{
				options.UseLazyLoadingProxies()
					   .UseInMemoryDatabase("InMemoryDbForTesting");
			});
		});
	}
}