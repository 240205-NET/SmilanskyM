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
		// Add your Countdown properties here
	}

	[Serializable]
	public class Session : Countdown
	{
		public string name { get; set; }
		// public Session() { } // Remove this if not needed
		public Session()
		{
			this.name = string.Empty; // Default non-null value
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

		public static void AppendTimerToXml(string timerName)
		{
			Timer newTimerToAppendToXml = new Timer(timerName);

			XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));

			List<Timer> listToStoreStoredTimersIn = TimerSerializer.DeserializeFromXml("timers.xml");

			listToStoreStoredTimersIn.Add(newTimerToAppendToXml);

			SerializeToXml(listToStoreStoredTimersIn, "timers.xml");
		}

		public static Timer GetTimerByName(string name)
		{
			List<Timer> timers = DeserializeFromXml("timers.xml");
			Timer timer = timers.FirstOrDefault(timer => timer.name == name);
			Console.Write(timer.name);
			return timer;
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
			TimerSerializer.GetTimerByName("My Timer 3");
		}
	}
}
