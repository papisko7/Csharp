namespace StarWarsPlanetsData
{
	public readonly record struct Planet
	{
		public string Name { get; }

		public int Diameter { get; }

		public int? SurfaceWater { get; }

		public int? Population { get; }

		public Planet(string name, int diameter, int? surfaceWater, int? population)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			Name = name;
			Diameter = diameter;
			SurfaceWater = surfaceWater;
			Population = population;
		}

		public static explicit operator Planet(Result item)
		{
			string name = item.Name;
			int diameter = int.Parse(item.Diameter);

			int? population = item.Population.ToIntOrNull();
			int? surfaceWater = item.SurfaceWater.ToIntOrNull();

			return new Planet(name, diameter, surfaceWater, population);
		}
	}
}
