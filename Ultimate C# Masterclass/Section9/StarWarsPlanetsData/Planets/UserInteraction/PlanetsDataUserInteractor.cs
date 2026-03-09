using StarWarsPlanetsData.UserInteraction;

namespace StarWarsPlanetsData.Planets.UserInteraction
{
	public class PlanetsDataUserInteractor(
		IUserInteractor userInteractor)
		: IPlanetsDataUserInteractor
	{
		public void Show(IEnumerable<Planet> planets)
		{
			TablePrinter.Print(planets);
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

	public class TablePrinter
	{
		private const int COLUMN_WIDTH = 20;

		public static void Print<T>(IEnumerable<T> items)
		{
			var properties = typeof(T).GetProperties();

			foreach (var property in properties)
			{
				Console.Write($"{{0, -{COLUMN_WIDTH}}}|", property.Name);
			}

			Console.WriteLine();
			Console.WriteLine(new string('-',
				properties.Length * (COLUMN_WIDTH + 1)));
			Console.WriteLine();

			foreach (var item in items)
			{
				foreach (var property in properties)
				{
					var value = property.GetValue(item)?.ToString() ?? string.Empty;
					Console.Write($"{{0, -{COLUMN_WIDTH}}}|", value);
				}
				Console.WriteLine();
			}
		}
	}
}
