namespace CookieCookBook
{
    internal class Recipe
    {
        private List<Ingredient> _ingredients;

        public void DisplayIngredients()
        {
            foreach (var ingredient in _ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }
    }
}