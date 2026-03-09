using StarWarsPlanetsData.Planets.UserInteraction;

namespace StarWarsPlanetsData.Planets.Analyzing
{
	public class PlanetsDataAnalyzer(IPlanetsDataUserInteractor userInteractor)
		: IPlanetsDataAnalyzer
	{
		public void Analyze(IEnumerable<Planet> planets)
		{
			var propertyNamesToSelectorMapping = new Dictionary<string,
				Func<Planet,
					long?>>()
			{
				["population"] = p => p.Population,
				["diameter"] = p => p.Diameter,
				["surface water"] = p => p.SurfaceWater
			};

			var userInput = userInteractor.ChooseDataToBeShown(propertyNamesToSelectorMapping.Keys);

			if (userInput is null || !propertyNamesToSelectorMapping.TryGetValue(userInput,
					out var value))
			{
				userInteractor.ShowMessage("Invalid input!");
			}
			else
			{
				ShowData(planets,
					userInput,
					value);
			}
		}

		private void ShowData(IEnumerable<Planet> planets,
			string propertyName,
			Func<Planet, long?> propertySelector)
		{
			var enumerable = planets as Planet[] ?? planets.ToArray();

			ShowData("Max",
				enumerable.MaxBy(propertySelector),
				propertySelector,
				propertyName);
			ShowData("Min",
				enumerable.MinBy(propertySelector),
				propertySelector,
				propertyName);
		}

		private void ShowData(string descriptor,
			Planet selectedPlanet,
			Func<Planet, long?> propertySelector,
			string propertyName)
		{
			userInteractor.ShowMessage(descriptor + " " + propertyName + " is: " +
							  propertySelector(selectedPlanet) + " planet: " +
							  selectedPlanet.Name);
		}
	}
}
