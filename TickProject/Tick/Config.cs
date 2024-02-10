using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Tick
{

	public class Config
	{
		private string path = @".\config.xml";
		public List<Timer> timers { get; set; }

		public Config() { }


		public void AddTimer(Timer timer)
		{
			// 1) check if the config file exists
			// 2) if it does exist, check if there are any Timers in it. 
			//		if there are timers in it, add the timer to the existing list
			// if not, create a new list of Timers are add a new to the list
			List<Timer> timers;
			if (File.Exists(this.path))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
				timers = this.DeserializeFromXml("timers.xml");
			}
			else
			{
				timers = new List<Timer>();
			}

			timers.Add(timer);
			this.SerializeToXml(timers, "timers.xml");
		}

		public void SerializeToXml(List<Timer> timers, string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
			using (TextWriter writer = new StreamWriter(filePath))
			{
				serializer.Serialize(writer, timers);
			}
		}

		public List<Timer> DeserializeFromXml(string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
			using (TextReader reader = new StreamReader(filePath))
			{
				return (List<Timer>)serializer.Deserialize(reader);
			}
		}
		// public void AddTimer(string timerName)
		// {
		// 	Timer newTimer = new Timer(timerName);
		// 	XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
		// 	List<Timer> timers = this.DeserializeFromXml("timers.xml");
		// 	timers.Add(newTimer) ?? new List<Timer>();
		// 	this.SerializeToXml(timers, "timers.xml");
		// }

		public Timer GetTimer(string name)
		{
			List<Timer> timers = this.DeserializeFromXml("timers.xml");
			Timer timer = timers.FirstOrDefault(timer => timer.name == name);
			return timer;
		}

		public Timer EditTimer(string name)
		{
			List<Timer> timers = this.DeserializeFromXml("timers.xml");
			Timer timer = timers.FirstOrDefault(timer => timer.name == name);
			timer.name = name;
			this.SerializeToXml(timers, "timers.xml");
			return timer;
		}

		public void RemoveTimer(string name)
		{
			List<Timer> timers = this.DeserializeFromXml("timers.xml");
			timers.RemoveAll(t => t.name == name);
			this.SerializeToXml(timers, "timers.xml");
		}

	}

}