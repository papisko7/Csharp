using NBomber.CSharp;

namespace MvcApp.Tests.Performance;

public class ApiPerformanceTests
{
	[Fact]
	public void Endpoints_WhenLoadTested_ReturnsValidPerformanceMetrics()
	{
		using var httpClient = new HttpClient();

		var scenario = Scenario.Create("api_performance_scenario", async context =>
		{
			const string baseUrl = "http://localhost:5003";

			try
			{
				var responseStudents = await httpClient.GetAsync($"{baseUrl}/api/students");
				var responseGroups = await httpClient.GetAsync($"{baseUrl}/api/groups");

				if (responseStudents.IsSuccessStatusCode && responseGroups.IsSuccessStatusCode)
				{
					return Response.Ok();
				}

				return Response.Fail(message: "API returned non-success status code.");
			}
			catch (Exception ex)
			{
				return Response.Fail(message: ex.Message);
			}
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(5))
		.WithLoadSimulations(
			Simulation.RampingConstant(copies: 20, during: TimeSpan.FromSeconds(15)),
			Simulation.KeepConstant(copies: 20, during: TimeSpan.FromSeconds(30)),
			Simulation.RampingConstant(copies: 0, during: TimeSpan.FromSeconds(15))
		);

		var stats = NBomberRunner
			.RegisterScenarios(scenario)
			.Run();

		Assert.NotNull(stats);
		Assert.NotEmpty(stats.ScenarioStats);
	}
}