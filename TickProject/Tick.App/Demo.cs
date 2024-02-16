namespace Tick.App
{
	public class Demo
	{
		readonly Menu menu;
		public bool timerActive = true;
		public Demo(Menu menu)
		{
			this.menu = menu;
		}

		public void HandleCurrentModeDemo(Timer timer)
		{
			// Set the currentDuration based on the currentMode
			timer.currentDuration = timer.currentMode == "Session" ?
			timer.countdowns[0].duration :
			timer.currentMode == "Short Break" ?
			timer.countdowns[1].duration :
			timer.countdowns[2].duration;
			while (timer.currentDuration >= 0)
			{
				if (!this.timerActive)
				{
					// This occurs when the user presses 'ESC'
					Console.Clear();
					return;
				}
				if (!timer.paused)
				{
					// If the timer isn't paused, display the updated timer state and elapse the timer
					this.menu.DisplayTimerState(timer);
					timer.currentDuration--;
				}
				else
				{
					// Otherwise, just show the timer state
					this.menu.DisplayTimerState(timer);
				}
				Thread.Sleep(1000);
			}
			// Once at this point, the timer is over and we set the next mode
			if (timer.currentMode == "Session")
			{
				// If it's time for a long break 
				if (timer.longBreakCounter == 0)
				{
					// Set the current mode to Long Break and Reset the Long Break counter 
					timer.currentMode = "Long Break";
					timer.longBreakCounter = timer.longBreakInterval + 1;
				}
				else
				{
					// Otherwise, just move on to the Short Break
					timer.currentMode = "Short Break";
				}
				// The Long Break Counter will always be decremented after a Session is over
				timer.longBreakCounter--;
			}

			else if (timer.currentMode == "Short Break" || timer.currentMode == "Long Break")
			{
				// Set the next mode to Session if it's one of the breaks 
				timer.currentMode = "Session";
			}
			Console.Clear();
		}
		public void RunTimerDemo(Timer timer)
		{
			this.timerActive = true;
			Thread keyListener = new Thread(() =>
			{
				while (this.timerActive)
				{
					ConsoleKeyInfo keyInfo = Console.ReadKey(true);

					if (keyInfo.KeyChar == 'p' || keyInfo.KeyChar == 'P')
					{
						timer.paused = true;
					}
					else if (keyInfo.KeyChar == 'c' || keyInfo.KeyChar == 'C')
					{
						timer.paused = false;
					}
					else if (keyInfo.Key == ConsoleKey.Escape)
					{
						this.timerActive = false;
						return;
					}
				}
			});

			keyListener.Start();
			while (this.timerActive)
			{
				this.HandleCurrentModeDemo(timer);
			}
		}
	}
}