using StarWarsPlanetsData.Planets.Analyzing;
using StarWarsPlanetsData.Planets.Reading;
using StarWarsPlanetsData.Planets.UserInteraction;

namespace StarWarsPlanetsData
{
	public class StarWarsPlanetsDataApp(
		IPlanetsReader planetsReader,
		IPlanetsDataAnalyzer planetsDataAnalyzer,
		IPlanetsDataUserInteractor userInteractor)
	{
		public async Task Run()
		{
			var planets = await planetsReader.Read();
			var enumerableOfPlanets = planets.ToList();

			userInteractor.Show(enumerableOfPlanets);
			planetsDataAnalyzer.Analyze(enumerableOfPlanets);
		}
	}
}
