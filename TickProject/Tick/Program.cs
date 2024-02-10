using System;

namespace Tick
{

	public class Program
	{

		public static void Main()
		{
			Config config = new Config();

			Timer newTimer = new Timer("My Super Awesome Timer 2");
			config.AddTimer(newTimer);
		}
	}

}