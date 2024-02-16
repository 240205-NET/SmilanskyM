using System;
using System.Text;
namespace Tick.App
{
	public class Menu
	{
		public string currentView;
		public Menu()
		{
			this.currentView = "Main Menu"; // "Main Menu" is the default view.
		}
		public void SetCurrentView(string currentView)
		{
			this.currentView = currentView;
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
				formattedTimers.AppendLine("Uh oh, you don't have any timers!");
				return formattedTimers.ToString();
			}
			else
			{
				int count = 1;
				foreach (Timer t in timers)
				{
					formattedTimers.AppendLine($"{count}) {t.name}\n");
					formattedTimers.AppendLine($"  {t.countdowns[0].duration} (Session)");
					formattedTimers.AppendLine($"  {t.countdowns[1].duration} (Short Break)");
					formattedTimers.AppendLine($"  {t.countdowns[2].duration} (Long Break)");
					formattedTimers.AppendLine($"  {t.longBreakInterval} (Long Break Interval)\n");
					count++;
				}
			}
			return formattedTimers.ToString();
		}


		public void DisplayMenuView()
		{
			Console.WriteLine("Select a number (1-4) from the options below:\n");
			Console.WriteLine("1: Start Timer");
			Console.WriteLine("2: Add Timer");
			Console.WriteLine("3: View Timers");
			Console.WriteLine("4: Delete Timer");
			Console.WriteLine("5: Demo Mode\n");
		}

		public void DisplayWelcomeMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Welcome to Tick! A Pomodoro timer for the Console.\n");
			Console.ResetColor();
		}

		public static string DisplayTimerPaused(Timer timer)
		{
			// 8 blank spaces effectively erases the (paused) text without having to Console.Clear()
			return timer.paused ? "(paused)" : "        ";
		}
		public void DisplayTimerState(Timer timer)
		{
			// The StringBuilder approach (as opposed to using Console.WriteLine()s) is advantageous because:
			// 1) The cursor position only needs to be set once as opposed to on every line we want to draw the text
			// 2) There are graphical glitches that surface when using WriteLines, especially when resizing the terminal window (duplicate lines, displaced text, etc.)
			StringBuilder output = new StringBuilder();

			Console.SetCursorPosition(0, 0);

			output.Append($"Sessions until Long Break: {timer.longBreakCounter}\n\n");
			output.Append($"Current mode: {timer.currentMode}\n\n");
			output.Append($"Timer: {Menu.FormatTime(timer.currentDuration)} {Menu.DisplayTimerPaused(timer)}\n\n");
			output.Append("(P) - PAUSE        (C) CONTINUE        (ESC) QUIT TO MENU");

			Console.Write(output.ToString());

			Console.SetCursorPosition(0, 0);
		}

		public static string FormatTime(int totalSeconds)
		{
			int minutes = totalSeconds / 60;
			int seconds = totalSeconds % 60;
			// Formats the countdown as "mm:ss"
			return $"{minutes:D2}:{seconds:D2}";
		}
		public static string FormatTimeDemo(int totalSeconds)
		{
			return $"{totalSeconds}";
		}
	}
}