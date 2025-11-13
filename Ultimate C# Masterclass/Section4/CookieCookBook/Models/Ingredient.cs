namespace CookieCookBook.Models
{
	public class Ingredient
	{
		public int Id { get; set; }

		public string Instruction { get; set; }

		public string Name { get; set; }

		public Ingredient(int id, string name, string instruction)
		{
			Id = id;
			Name = name;
			Instruction = instruction;
		}
	}
}