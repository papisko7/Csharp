namespace StarWarsPlanetsData.Planets.Reading;

public interface IPlanetsReader
{
	Task<IEnumerable<Planet>> Read();
}
