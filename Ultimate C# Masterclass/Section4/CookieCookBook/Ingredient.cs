namespace CookieCookBook
{
	public class Ingredient
	{
		private int ID { get; set; }

		private string Name { get; set; }

		private string Instructions { get; set; }

		public Ingredient(int id, string name, string instructions)
		{
			ID = id;
			Name = name;
			Instructions = instructions;
		}
	}
}