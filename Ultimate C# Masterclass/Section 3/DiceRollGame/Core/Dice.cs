namespace DiceRollGame.Core
{
	public static class Dice
	{
		public static int GetRandomNumberFrom1To6()
		{ 
			return Random.Shared.Next(1, 7);
		}
	}
}