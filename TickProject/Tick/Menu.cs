namespace Tick.App
{
	public class Menu
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

		public static string DisplayTimerPaused(Timer timer)
		{
			return timer.paused ? "TIMER PAUSED" : "TIMER ACTIVE";
		}
		public void DisplayTimerState(Timer timer)
		{
			// SetCursorPosition + WriteLine = redraw text starting at this specific coordinate
			// 0, Console.CursorTop = Line 1, Col 1
			Console.CursorVisible = false;
			Console.SetCursorPosition(0, 0);
			Console.WriteLine($"Sessions until long break: {timer.longBreakCounter}\n");

			// 0, 1 = Line 1, Col 2
			//
			Console.SetCursorPosition(0, 1);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 1);
			Console.Write($"Elapsed {timer.currentMode} Time: {Menu.FormatTime(timer.currentDuration)}");

			Console.SetCursorPosition(0, 4);
			Console.Write(Menu.DisplayTimerPaused(timer));

			Console.SetCursorPosition(0, 6);
			Console.Write("(P) - PAUSE        (C) CONTINUE        (ESC) QUIT TO MENU");
		}

		public static string FormatTime(int totalSeconds)
		{
			int minutes = totalSeconds / 60;
			int seconds = totalSeconds % 60;
			return $"{minutes:D2}:{seconds:D2}"; // Formats the string to "MM:SS"
		}


	}
}