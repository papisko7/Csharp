namespace DiceRollGame.Core
{
	public static class Answer
	{
		public static bool IsCorrect(string userInputString, int randomNumber)
		{
			int userInput;

			if (!int.TryParse(userInputString, out userInput))
			{
				Console.WriteLine("Incorrect input");
				return false;
			}

			else if(userInput == randomNumber)
			{
				Console.WriteLine("Congratulations! You guessed the correct number.");
				return true;
			}

			else
			{
				Console.WriteLine("Wrong number");
				AnswerCounter.IncrementCounter();
				return false;
			}
		}	
	}
}