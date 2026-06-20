using MvcApp.Annotations;
using MvcApp;

var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var context = services.GetRequiredService<StudentDbContext>();
		context.Database.EnsureCreated();

		if (!context.Groups.Any())
		{
			var group1 = new Group { Name = "Group 1" };
			var group2 = new Group { Name = "Group 2" };

			var students = new List<Student>
			{
				new() { FirstName = "Jan", LastName = "Kowalski", Age = 20, Group = group1 },
				new() { FirstName = "Anna", LastName = "Nowak", Age = 21, Group = group1 },

				new() { FirstName = "Michael", LastName = "Wiśniewski", Age = 22, Group = group2 },
				new() { FirstName = "Katarzyna", LastName = "Doe", Age = 23, Group = group2 },
				new() { FirstName = "Piotr", LastName = "Meankieli", Age = 21, Group = group2 }
			};

			context.Groups.AddRange(group1, group2);
			context.Students.AddRange(students);

			context.SaveChanges();
		}
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred creating the DB.");
	}
}
host.Run();
return;

static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.ConfigureWebHostDefaults(webBuilder =>
		{
			webBuilder.UseStartup<Startup>();
		});