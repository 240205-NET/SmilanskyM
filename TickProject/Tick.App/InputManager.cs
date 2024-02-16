namespace Tick.App
{

	public static class InputManager
	{
		// TODO add test for this
		public static int GetInt()
		{
			int num;
			while (!Int32.TryParse(Console.ReadLine(), out num))
			{
				Console.Write("Sorry, that input is invalid; you must enter a number: ");
			}
			return num;
		}
	}
}