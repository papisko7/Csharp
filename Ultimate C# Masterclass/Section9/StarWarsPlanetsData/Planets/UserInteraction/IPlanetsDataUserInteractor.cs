namespace StarWarsPlanetsData.Planets.UserInteraction
{
	public interface IPlanetsDataUserInteractor
	{
		void Show(IEnumerable<Planet> planets);

		string? ChooseDataToBeShown(IEnumerable<string> propertiesThatCanBeChosen);

		void ShowMessage(string message);
	}
}
