using System;
using System.IO;

namespace Tick
{

	public class Config
	{
		public string path { get; set; }
		public List<Timer> timers { get; set; }

		public Config(path = @".\config.txt") { }

	}

	public AddTimer(Timer timer)
	{
		// 1) check if the config file exists
		// 2) if it does exist, check if there are any Timers in it. 
		//		if there are timers in it, add the timer to the existing list
		// if not, create a new list of Timers are add a new to the list
		if (File.Exists(this.path))
		{
			List<timer> savedTimers = DeserializeXML(this.path)
		}
	}

	public DeleteTimer()
	{

	}

	public GetTimer(string name)
	{


	}

	public GetAllTimers()
	{

	}




}