namespace Tick.App
{
	[Serializable]
	public class Timer
	{
		public List<Countdown> countdowns { get; set; }
		public string name { get; set; }
		public Timer()
		{
			this.name = "Name";
		}

		public Timer(string name)
		{
			this.name = name;
			this.countdowns = new List<Countdown>();

			this.countdowns.Add(new Session(30));
			this.countdowns.Add(new ShortBreak(5));
			this.countdowns.Add(new LongBreak(10, 5));
		}
	}
}
