namespace CookieCookBook.Recipes.Ingredients.Interfaces
{
	public abstract class Ingredient
	{
		public abstract int ID { get; }

		public abstract string Name { get; }

		public virtual string PreperationInstruction => "Add to other ingredients.";
	}
}