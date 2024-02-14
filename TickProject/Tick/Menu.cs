using System;
using System.Text;
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
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("+++++++++++++++++++++++++");
			Console.WriteLine($" {this.currentView}");
			Console.WriteLine("+++++++++++++++++++++++++\n");
			Console.ResetColor();
		}

		public string FormatTimerList(List<Timer> timers)
		{
			StringBuilder formattedTimers = new StringBuilder();
			int currentTimer = 0;
			if (timers.Count < 1)
			{
				formattedTimers.AppendLine("Uh oh, you don't have any timers to view!");
				return formattedTimers.ToString();
			}
			else
			{
				currentTimer = 1;
				formattedTimers.AppendLine($"You have {timers.Count} timers in your config: \n");
				foreach (Timer t in timers)
				{
					formattedTimers.AppendLine($"{currentTimer}): {t.name}\n");
					formattedTimers.AppendLine($"Session: {t.countdowns[0].duration}");
					formattedTimers.AppendLine($"Short Break: {t.countdowns[1].duration}");
					formattedTimers.AppendLine($"Long Break: {t.countdowns[2].duration}");
					formattedTimers.AppendLine($"Long Break Interval: {t.longBreakInterval}\n\n");
					currentTimer++;
				}
			}
			return formattedTimers.ToString();
		}
		public void SetCurrentView(string currentView)
		{
			this.currentView = currentView;
		}

		public void DisplayMenuView()
		{
			Console.WriteLine("Choose a number (1-4) from the options below:\n");
			Console.WriteLine("1: Choose Timer");
			Console.WriteLine("2: Add Timer");
			Console.WriteLine("3: View Timers");
			Console.WriteLine("4: Delete Timer\n");
		}

		public void DisplayWelcomeMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Welcome to Tick! A Pomodoro timer for the Console.\n");
			Console.ResetColor();
		}

		public static string DisplayTimerPaused(Timer timer)
		{
			return timer.paused ? "TIMER PAUSED" : "TIMER ACTIVE";
		}
		public void DisplayTimerState(Timer timer)
		{
			// // SetCursorPosition + WriteLine = redraw text starting at this specific coordinate
			// // 0, Console.CursorTop = Line 1, Col 1
			// Console.CursorVisible = false;
			// Console.SetCursorPosition(0, 0);
			// Console.WriteLine($"Sessions until long break: {timer.longBreakCounter}\n");

			// // 0, 1 = Line 1, Col 2
			// //
			// Console.SetCursorPosition(0, 1);
			// Console.Write(new string(' ', Console.WindowWidth));
			// Console.SetCursorPosition(0, 1);
			// Console.Write($"Elapsed {timer.currentMode} Time: {Menu.FormatTime(timer.currentDuration)}");

			// Console.SetCursorPosition(0, 4);
			// Console.Write(Menu.DisplayTimerPaused(timer));

			// Console.SetCursorPosition(0, 6);
			// Console.Write("(P) - PAUSE        (C) CONTINUE        (ESC) QUIT TO MENU");
			// SetCursorPosition + WriteLine = redraw text starting at this specific coordinate
			// 0, Console.CursorTop = Line 1, Col 1
			StringBuilder output = new StringBuilder();

			Console.SetCursorPosition(0, 0);

			output.Append($"Sessions until Long Break: {timer.longBreakCounter}\n");
			output.Append($"Currently mode: {timer.currentMode}\n");
			output.Append(Menu.DisplayTimerPaused(timer) + "\n\n");
			output.Append($"Timer: {Menu.FormatTime(timer.currentDuration)}\n\n");
			output.Append("(P) - PAUSE        (C) CONTINUE        (ESC) QUIT TO MENU");

			Console.Write(output.ToString());
		}

		public static string FormatTime(int totalSeconds)
		{
			int minutes = totalSeconds / 60;
			int seconds = totalSeconds % 60;
			return $"{minutes:D2}:{seconds:D2}"; // Formats the string to "MM:SS"
		}


	}
}