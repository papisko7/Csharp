namespace StarWarsPlanetsData.Planets.Analyzing;

public interface IPlanetsDataAnalyzer
{
	void Analyze(IEnumerable<Planet> planets);
}
