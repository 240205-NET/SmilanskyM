namespace Tick
{
	public class Timer
	{
		public Dictionary<Countdown> countdowns { get; set; }

		public Timer()
		{
			this.name = name;
			this.countdowns = new Dictionary<Countdown>()
		{
			{ "Session": new Session(30) },
			{ "Short Break": new Session(5) },
			{ "Long Break": new Session(10 , 5) }
		}
		}
	}

}