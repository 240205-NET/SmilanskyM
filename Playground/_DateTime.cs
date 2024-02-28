using System;
using System.Globalization;

namespace Playground
{
	public class _DateTime
	{
		public static void Run()
		{
			// Get the current Unix time in seconds
			long currentTimeInSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			TimeZoneInfo localZone = TimeZoneInfo.Local;
			Console.WriteLine(localZone.Id);
			// Convert the Unix time back to a DateTimeOffset
			DateTimeOffset UTCDateTime = DateTimeOffset.FromUnixTimeSeconds(currentTimeInSeconds);
			// Print the UTC date and time
			Console.WriteLine("Local timezone: " + localZone);
			Console.WriteLine("UTC Date and time with offset: " + UTCDateTime);
		}
	}
}