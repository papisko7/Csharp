namespace CookieCookBook.Recipes.Ingredients.Interfaces
{
    public abstract class Flour : Ingredient
    {
        public override string PreperationInstruction => $"Sieve. {base.PreperationInstruction}";
	}
}