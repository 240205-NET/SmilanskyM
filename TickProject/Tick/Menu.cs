namespace Tick.App
{
	class Menu
	{
		public string currentView;
		public Menu()
		{
			this.currentView = "Main Menu";
		}

		public void GetCurrentView()
		{
			Console.WriteLine("+++++++++++++++++++++++++");
			Console.WriteLine($" {this.currentView}");
			Console.WriteLine("+++++++++++++++++++++++++\n");
		}

		public void SetCurrentView(string currentView)
		{
			this.currentView = currentView;
		}

		public void DisplayMenuView()
		{
			Console.WriteLine("Choose a number (1-5) from the options below:\n");
			Console.WriteLine("1: Choose Timer");
			Console.WriteLine("2: Add Timer");
			Console.WriteLine("3: View Timers");
			Console.WriteLine("5: Delete Timer\n");
		}

		public void DisplayWelcomeMessage()
		{
			Console.WriteLine("Welcome to Tick! The greatest Pomodoro CLI ever created.\n");
		}

	}
}