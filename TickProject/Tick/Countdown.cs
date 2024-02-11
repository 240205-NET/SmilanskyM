// Countdown must be abstract since each type of countdown (session, short break, long break) 
// should have somewhat unique functionality and features 
// For instance, the abstract Countdown class has an abstract Alert() function so that
// Each type of countdown can alert the user when it's over in a different way (contextually speaking).
using System.Xml.Serialization;
namespace Tick.App
{

	[Serializable]
	[XmlInclude(typeof(Session))]
	[XmlInclude(typeof(ShortBreak))]
	[XmlInclude(typeof(LongBreak))]
	public abstract class Countdown
	{
		public int duration { get; set; }

		public Countdown(int duration)
		{
			this.duration = duration;
		}
		public abstract string Alert();

	}

	public class Session : Countdown
	{
		public Session() : base(30)
		{

		}
		public Session(int duration) : base(duration) { }
		public override string Alert()
		{
			return "Time for a break!";
		}
	}

	public class ShortBreak : Countdown
	{
		// put interval long break here?
		public ShortBreak() : base(10)
		{

		}
		public ShortBreak(int duration) : base(duration)
		{

		}

		public override string Alert()
		{
			return "That was a nice and short break! Back to work!";
		}
	}

	public class LongBreak : Countdown
	{
		public int interval { set; get; }
		public int intervalCounter { set; get; } = 0;

		public LongBreak() : base(5)
		{ }
		public LongBreak(int duration, int interval) : base(duration)
		{
			this.interval = interval;
		}
		public override string Alert()
		{
			return "That was a nice and long break! Back to work!";
		}
	}
}