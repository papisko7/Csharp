namespace DiceRollGame.Core
{
	public static class AnswerCounter
	{
		public static int Counter { get; private set;  }

		public static void IncrementCounter()
		{
			Counter++;
		}
	}
}