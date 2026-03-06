using StarWarsPlanetsData.ApiDataAccess;
using System.Numerics;
using System.Text.Json;

namespace StarWarsPlanetsData
{
	public class StarWarsPlanetsDataApp(IApiDataReader apiDataReader, IApiDataReader mockApiDataReader)
	{
		private readonly IApiDataReader _apiDataReader = apiDataReader;
		private readonly IApiDataReader _mockApiDataReader = mockApiDataReader;

		public async Task Run()
		{
			string? jsonData = null;

			try
			{
				jsonData = await _apiDataReader.Read("https://swapi.dev", "api/planets");

			}
			catch (Exception ex)
			{
				Console.WriteLine("API request was unsuccessful. " +
					"Switching to mock data. " +
					"Exception message: " + ex.Message);
			}

			jsonData ??= await _mockApiDataReader.Read("https://swapi.dev", "api/planets");

			var root = JsonSerializer.Deserialize<Root>(jsonData);
			var planets = ToPlanets(root);

			foreach (var planet in planets)
			{
				Console.WriteLine(planet);
			}

			var propertyNamesToSelectorMapping = new Dictionary<string, Func<Planet, int?>>()
			{
				["population"] = p => p.Population,
				["diameter"] = p => p.Diameter,
				["surface water"] = p => p.SurfaceWater
			};

			Console.WriteLine();
			Console.WriteLine("The statistics of which property would you like to see?");
			Console.WriteLine(string.Join(Environment.NewLine,
				propertyNamesToSelectorMapping.Keys));

			string? userInput = Console.ReadLine()?.ToLower();

			if (userInput is null || !propertyNamesToSelectorMapping.TryGetValue(userInput, out Func<Planet, int?>? value))
			{
				Console.WriteLine("Invalid input!");
			}
			else
			{
				ShowData(planets,
					userInput,
value);
			}
		}

		private static IEnumerable<Planet> ToPlanets(Root? root)
		{
			ArgumentNullException.ThrowIfNull(root);
			return root.Results.Select(
				planetDto => (Planet)planetDto);
		}

		private static void ShowData(IEnumerable<Planet> planets,
			string propertyName,
			Func<Planet, int?> propertySelector)
		{
			ShowData("Max",
				planets.MaxBy(propertySelector),
				propertySelector,
				propertyName);
			ShowData("Min",
				planets.MinBy(propertySelector),
				propertySelector,
				propertyName);
		}

		private static void ShowData(string descriptor, Planet selectedPlanet, Func<Planet, int?> propertySelector, string propertyName)
		{

			Console.WriteLine(descriptor + " " + propertyName + " is: " +
				propertySelector(selectedPlanet) + " planet: " +
				selectedPlanet.Name);
		}
	}
}
