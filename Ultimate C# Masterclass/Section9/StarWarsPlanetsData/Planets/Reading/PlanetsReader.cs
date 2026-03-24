using System.Text.Json;
using StarWarsPlanetsData.ApiDataAccess;
using StarWarsPlanetsData.DTOs;
using StarWarsPlanetsData.UserInteraction;

namespace StarWarsPlanetsData.Planets.Reading
{
	public class PlanetsReader(
		IApiDataReader apiDataReader,
		IApiDataReader mockApiDataReader,
		IUserInteractor userInteractor)
		: IPlanetsReader
	{
		public async Task<IEnumerable<Planet>> Read()
		{
			string? jsonData = null;

			try
			{
				jsonData = await apiDataReader.Read(
						"https://swapi.dev",
						"api/planets");
			}
			catch (Exception ex)
			{
				userInteractor.ShowMessage("API request was unsuccessful. " +
								  "Switching to mock data. " +
								  "Exception message: " + ex.Message);
			}

			jsonData ??= await mockApiDataReader.Read("https://swapi.dev",
				"api/planets");

			var root = JsonSerializer.Deserialize<Root>(jsonData);
			return ToPlanets(root);
		}

		private static IEnumerable<Planet> ToPlanets(Root? root)
		{
			ArgumentNullException.ThrowIfNull(root);
			return root.Results.Select(
				planetDto => (Planet)planetDto);
		}
	}
}
