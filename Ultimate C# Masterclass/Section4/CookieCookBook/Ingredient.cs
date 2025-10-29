namespace CookieCookBook
{
	public class Ingredient
	{
		private int _id;

		private string _name;

		private string _instructions;

		public Ingredient(int id, string name, string instructions)
		{
			_id = id;
			_name = name;
			_instructions = instructions;
		}

		public string GetName() => _name;

		public string GetInstructions() => _instructions;

		public string ToString() => $"{_id}. {_name}";
	}
}