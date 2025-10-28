namespace DiceRollGame.Core
{
	public class Game
	{
		private int _randomNumber;

		public Game(int randomNumber) 
		{
			_randomNumber = randomNumber;
		}

		public void start()
		{
			string userInputString = string.Empty;
			Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

			do
			{	
				Console.Write("Enter your guess (1-6): ");
				userInputString = Console.ReadLine();

				if (Answer.IsCorrect(userInputString, _randomNumber)) 
				{
					return;
				}
			} while (AnswerCounter.Counter < 3);
			Console.WriteLine("You lose");
		}
	}
}