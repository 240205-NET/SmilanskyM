using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Tick
{
	[Serializable]
	[XmlInclude(typeof(Session))]
	public class Countdown
	{
	}

	[Serializable]
	public class Session : Countdown
	{
		public string name { get; set; }
		public Session()
		{
			this.name = string.Empty;
		}
		public Session(string name)
		{
			this.name = name;
		}
	}

	[Serializable]
	public class Timer
	{
		public string name { set; get; }
		public List<Countdown> Countdowns { get; set; }
		public Timer() { }
		public Timer(string name)
		{
			this.name = name;
			this.Countdowns = new List<Countdown>
			{
				new Session("hi"),

			};
		}
	}

	public static class TimerSerializer
	{
		public static void SerializeToXml(List<Timer> timers, string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
			using (TextWriter writer = new StreamWriter(filePath))
			{
				serializer.Serialize(writer, timers);
			}
		}

		public static List<Timer> DeserializeFromXml(string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
			using (TextReader reader = new StreamReader(filePath))
			{
				return (List<Timer>)serializer.Deserialize(reader);
			}
		}

		public static void AddTimer(string timerName)
		{
			Timer newTimer = new Timer(timerName);
			XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
			List<Timer> timers = TimerSerializer.DeserializeFromXml("timers.xml");
			timers.Add(newTimer);
			SerializeToXml(timers, "timers.xml");
		}

		public static Timer GetTimer(string name)
		{
			List<Timer> timers = DeserializeFromXml("timers.xml");
			Timer timer = timers.FirstOrDefault(timer => timer.name == name);
			return timer;
		}

		public static Timer EditTimer(string name)
		{
			List<Timer> timers = DeserializeFromXml("timers.xml");
			Timer timer = timers.FirstOrDefault(timer => timer.name == name);
			timer.name = name;
			TimerSerializer.SerializeToXml(timers, "timers.xml");
			return timer;
		}

		public static void RemoveTimer(string name)
		{
			List<Timer> timers = DeserializeFromXml("timers.xml");
			timers.RemoveAll(t => t.name == name);
			TimerSerializer.SerializeToXml(timers, "timers.xml");
		}

	}

	class Program
	{
		static void Main()
		{
			List<Timer> timers = new List<Timer>
			{
				new Timer(),
			};

			// TimerSerializer.SerializeToXml(timers, "timers.xml");
			// TimerSerializer.AppendTimerToXml("My Timer 1");
			// TimerSerializer.AppendTimerToXml("My Timer 2");
			// TimerSerializer.AppendTimerToXml("My Timer 3");

			// edit a timer
			// TimerSerializer.GetTimerByName("My Timer 3");
			TimerSerializer.AddTimer("uwu new name");

		}
	}
}
