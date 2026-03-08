using StarWarsPlanetsData.DTOs;
using StarWarsPlanetsData.Extensions;

namespace StarWarsPlanetsData.Planets
{
	public readonly record struct Planet(string Name, int Diameter, int? SurfaceWater, int? Population)
	{
		public string Name { get; } = Name ?? throw new ArgumentNullException(nameof(Name));

		public static explicit operator Planet(Result item)
		{
			var name = item.Name;
			var diameter = int.Parse(item.Diameter);

			var population = item.Population.ToIntOrNull();
			var surfaceWater = item.SurfaceWater.ToIntOrNull();

			return new Planet(
				name,
				diameter,
				surfaceWater,
				population);
		}
	}
}
