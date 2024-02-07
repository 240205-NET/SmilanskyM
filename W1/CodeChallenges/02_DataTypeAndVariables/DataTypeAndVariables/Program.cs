using System;

namespace DataTypeAndVariables
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			byte myByte;
			sbyte mySbyte;
			int myInt;
			uint myUint;
			short myShort;
			ushort myUShort;
			float myFloat;
			double myDouble;
			char myCharacter;
			bool myBool;
			string myText;
			string numText;

			byte myByte_ = 8;
			sbyte mySbyte_ = 8;
			int myInt_ = 8;
			uint myUint_ = 8;
			short myShort_ = -8;
			ushort myUShort_ = 8;
			float myFloat_ = 3.3234f;
			double myDouble_ = 3.0;
			char myCharacter_ = 'A';
			bool myBool_ = true;
			string myText_ = "myText_";
			string numText_ = "8";
			decimal myDecimal = 3.0M;

			string iControlText = "I control text";
			string wholeNumber = "1";


		}

		public static int Text2Num(string numText)
		{
			int num;
			Int32.TryParse(numText, out num);
			return num;
		}
	}
}
