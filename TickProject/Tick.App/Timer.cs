namespace Tick.App
{
	[Serializable]
	public class Timer
	{
		public List<Countdown> countdowns { get; set; }
		public string name { get; set; }
		public int longBreakInterval { get; set; } = 4;
		public int longBreakCounter { get; set; } = 4;
		public string currentMode { get; set; } = "Session";
		public string nextMode { get; set; } = "Short Break";
		public int currentDuration { get; set; }
		public bool paused { get; set; } = false;
		public Timer()
		{
			this.name = "Name";
		}

		public Timer(string name, int sessionLength = 30, int shortBreakLength = 5, int longBreakLength = 10, int longBreakInterval = 4)
		{
			this.name = name;
			this.countdowns = new List<Countdown>();

			this.countdowns.Add(new Session(sessionLength));
			this.countdowns.Add(new ShortBreak(shortBreakLength));
			this.countdowns.Add(new LongBreak(longBreakLength, longBreakInterval));
			this.currentDuration = this.countdowns[0].duration;
			this.longBreakInterval = longBreakInterval;
			this.longBreakCounter = this.longBreakInterval;
		}
	}
}
