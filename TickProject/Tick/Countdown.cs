// Countdown must be abstract since each type of countdown (session, short break, long break) 
// should have somewhat unique functionality and features 
// For instance, the abstract Countdown class has an abstract Alert() function so that
// Each type of countdown can alert the user when it's over in a different way (contextually speaking).

namespace Tick
{

	public abstract class Countdown
	{
		public int duration { get; set; };

		public Countdown(int duration)
		{
			this.duration = duration;
		}
		public abstract string Alert();

	}

	public class Session : Countdown
	{
		public string Alert()
		{
			return "Time for a break!";
		}
	}

	public class ShortBreak : Countdown
	{
		// put interval long break here?

		public string Alert()
		{
			return "That was a nice and short break! Back to work!"
		}
	}

	public class LongBreak : Countdown
	{
		public int interval { set; get; };
		public int intervalCounter { set; get; };

		public Countdown(int duration, int interval) : base(duration)
		{
			this.interval = interval;
			this.intervalCounter = 0;
		}
		public string Alert()
		{
			return "That was a nice and long break! Back to work!"
		}
	}
}