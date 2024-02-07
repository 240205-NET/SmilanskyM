using System;

namespace GuessingGame
{
	public class GG
	{
		public static void Main(string[] args)
		{
			Game();
		}

		public static void Game()
		{
			// Greet the player
			Console.WriteLine("Welcome to the Guessing Game!");

			int target = CreateRandomNumber(21)

			// remove for production!
			Console.WriteLine(target);

			// something to remember if the player has won
			// boolean value to represent the yes or no
			bool win = false;

			// create the variable i, which we'll use to track how many attemps the player has made
			int i = 0;

			// loop to keep guessing until the player guesses the correct number
			while (!win) // C# comparison operators: ==, > , <, >=, <=, !=
			{
				win = GameLoop(target);
			}

			Console.WriteLine("Congratulations, you've won! It took you " + i + " attempts!");

			// promt to play again
			// if no, exit the progam
			// if yes, play again
		}

		public static bool GameLoop(int target)
		{
			int i = 0;
			bool win = false;
			Console.WriteLine("Please guess a number between 0 and 20: ");

			try
			{
				int guess = Int32.Parse(Console.ReadLine());


				if (guess >= 0 && guess <= 20)
				{
					if (guess == target)
					{
						Console.WriteLine("ayoo! Yay! Congratulations, you got it right!");
						win = true;
					}
					else if (guess > target)
					{
						Console.WriteLine("Whoops, too high!");
					}
					else
					{
						Console.WriteLine("Nope, too low!");
					}

					i++;
					Console.WriteLine("Attempt #: " + i);
				}
				else
				{
					Console.WriteLine("Your guess was out of range, please try again.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("The value you entered was not valid, please try again.");
			}

			return win;

		}

		public static int CreateRandomNumber(int limit)
		{
			// randomly generated number (for the player to try to guess)
			//var rand = new Random();
			Random rand = new Random();
			// uint (unsigned int) 0 - 2 Bill
			// int (signed int ) -1 Bill - 1 Bill
			// int target = rand.Next(limit); // generate an integer value between 0 and 20
			// return target;

			return rand.Next(limit);
		}
	}
}