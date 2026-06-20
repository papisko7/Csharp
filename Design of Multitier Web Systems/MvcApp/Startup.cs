using Microsoft.EntityFrameworkCore;

namespace MvcApp;

public class Startup(IConfiguration configuration)
{
	private IConfiguration Configuration { get; } = configuration;

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorPages();
		services.AddControllersWithViews();

		services.AddDbContext<StudentDbContext>(options => options
			.UseLazyLoadingProxies()
			.UseSqlServer(Configuration.GetConnectionString("StudentDbContext")));
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
	{
		loggerFactory.AddFile("Logs/system-log-{Date}.txt");

		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseRouting();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapRazorPages();
			endpoints.MapControllers();

			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
		});
	}
}