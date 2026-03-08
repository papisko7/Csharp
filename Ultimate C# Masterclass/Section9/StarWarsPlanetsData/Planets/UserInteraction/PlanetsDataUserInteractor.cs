using StarWarsPlanetsData.UserInteraction;

namespace StarWarsPlanetsData.Planets.UserInteraction
{
	public class PlanetsDataUserInteractor(
		IUserInteractor userInteractor)
		: IPlanetsDataUserInteractor
	{
		public void Show(IEnumerable<Planet> planets)
		{
			foreach (var planet in planets)
			{
				userInteractor.ShowMessage(
					planet.ToString());
			}
		}

		public string? ChooseDataToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
		{
			userInteractor.ShowMessage(Environment.NewLine);
			userInteractor.ShowMessage("The statistics of which property would you like to see?");
			userInteractor.ShowMessage(
				string.Join(Environment.NewLine,
					propertiesThatCanBeChosen));

			return userInteractor.GetUserInput()
				?.ToLower();
		}

		public void ShowMessage(string message)
		{
			userInteractor.ShowMessage(message);
		}
	}
}
