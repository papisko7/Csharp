using CookieCookBook;

List<Recipe> recipes = new List<Recipe>();

if (recipes.Count > 0)
{
    // end goal reading and displaing stuff from the text file onto the console

    Console.WriteLine("Printing existing recipes.");

    foreach (var recipe in recipes)
    {
        recipe.DisplayIngredients();
    }
}

Console.WriteLine("Create a new cookie recipe! Available ingredients are:");