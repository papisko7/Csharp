namespace CookieCookBook.Recipes.Ingredients.Interfaces
{
	public abstract class Ingredient
	{
		public abstract int Id { get; }

		public abstract string Name { get; }

		public virtual string PreperationInstruction => "Add to other ingredients.";

		public override string ToString()
		{
			return $"{Id}. {Name}";
		}
	}
}