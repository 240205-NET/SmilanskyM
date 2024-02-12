namespace Tick.App
{

	public class InputManager()
	{

		public static int GetInt()
		{
			bool success = false;
			int num;
			while (!Int32.TryParse(Console.ReadLine(), out num))
			{
				Console.Write("Sorry, that input is invalid; you must enter a number: ");
			}
			return num;
		}
	}
}