namespace CookieCookBook
{
	public class RecipesConsoleUserInteraction : IRecipesUserInteraction
	{
		public void Exit()
		{
			Console.WriteLine("Press any key to close.");
			Console.ReadKey();
		}

		public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}