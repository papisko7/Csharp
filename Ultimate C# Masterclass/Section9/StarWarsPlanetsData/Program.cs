using StarWarsPlanetsData;
using StarWarsPlanetsData.ApiDataAccess;
using StarWarsPlanetsData.Planets.Analyzing;
using StarWarsPlanetsData.Planets.Reading;
using StarWarsPlanetsData.Planets.UserInteraction;
using StarWarsPlanetsData.UserInteraction;

var consoleUserInteractor = new ConsoleUserInteractor();
var planetsDataUserInteractor = new PlanetsDataUserInteractor(consoleUserInteractor);

try
{
	await new StarWarsPlanetsDataApp(
		new PlanetsReader(
			new ApiDataReader(),
			new MockStarWarsApiDataReader(),
			consoleUserInteractor),
		new PlanetsDataAnalyzer(
			planetsDataUserInteractor),
		planetsDataUserInteractor).Run();
}
catch (Exception ex)
{
	consoleUserInteractor.ShowMessage("An unexpected error occurred. " +
		"Exception message: " + ex.Message);
}

consoleUserInteractor.ShowMessage("Press any key to close");
Console.ReadKey();
