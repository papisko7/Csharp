using StarWarsPlanetsData;
using StarWarsPlanetsData.ApiDataAccess;

try
{
	await new StarWarsPlanetsDataApp(
		new ApiDataReader(),
		new MockStarWarsApiDataReader()).Run();
}
catch (Exception ex)
{
	Console.WriteLine("An unexpected error occurred. " +
		"Exception message: " + ex.Message);
}

Console.WriteLine("Press any key to close");
Console.ReadKey();
