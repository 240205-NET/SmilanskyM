using System;

namespace Methods
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//1
			string name = GetName();
			GreetFriend(name);

			//2
			double result1 = GetNumber();
			double result2 = GetNumber();
			int action1 = GetAction();
			double result3 = DoAction(result1, result2, action1);

			System.Console.WriteLine($"The result of your mathematical operation is {result3}.");


		}

		public static string GetName()
		{
			string name = Console.ReadLine();
			return name;
		}

		public static void GreetFriend(string name)
		{
			//Greeting should be: Hello, nameVar. You are my friend
			//Ex: Hello, Jim. You are my friend
			Console.WriteLine($"Hello, {name}. You are my friend");
		}

		public static int GetAction()
		{
			// Should throw FormatException if the user did not input a number

			bool numberObtained = false;
			int n = 1;
			while (!numberObtained)
			{
				Console.WriteLine("Please enter an action number:");
				Console.WriteLine("1: Add");
				Console.WriteLine("2: Subtract");
				Console.WriteLine("3: Multiply");
				Console.WriteLine("4: Divide");

				try
				{
					n = Int32.Parse(Console.ReadLine());
					if (n >= 1 && n <= 4)
					{
						numberObtained = true;
					}
					else if (n > 4)
					{
						Console.WriteLine("Action too high! Only 1-4 is allowed.");
					}
					else
					{
						Console.WriteLine("Action too low! Only 1-4 is allowed.");
					}
				}
				catch (FormatException ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine($"The input you provided is invalid; please try again.");
				}
			}

			return n; // Move this line outside the while loop
		}

		public static double GetNumber()
		{
			Console.WriteLine("Please enter a number.");
			double n = double.Parse(Console.ReadLine());
			if (n.GetType() == typeof(double))
			{
				return n;
			}
			else
			{
				throw new FormatException("Incorrect format; please enter a double.");
			}
		}

		public static double DoAction(double x, double y, int z)
		{
			switch (z)
			{
				case 1:
					return x + y;
					break;
				case 2:
					return y - x;
					break;
				case 3:
					return x * y;
					break;
				case 4:
					return x / y;
					break;
				default:
					throw new FormatException("Invalid");
			}
		}
	}
}
