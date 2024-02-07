namespace BudgetApp
{
	public class Program
	{
		public static double budget;
		public static List<Dictionary<string, object>> expenses = new List<Dictionary<string, object>>();
		static void Main(string[] args)
		{
			budget = setInitialBudget();
			enterExpenses();
			displayExpenses();
		}

		public static double setInitialBudget()
		{
			Console.WriteLine("Please enter your initial budget");
			bool numberObtained = false;
			double initialBudget = 0;
			while (!numberObtained)
			{
				string userInput = Console.ReadLine();
				if (double.TryParse(userInput, out initialBudget))
				{
					Console.WriteLine($"Thank you. Budget set to {initialBudget}");
					numberObtained = true;
				}
				else
				{
					Console.WriteLine("Invalid input. Please try again with a double.");
				}
			}
			return initialBudget;
		}

		public static void enterExpenses()
		{
			Console.WriteLine("Please enter some expenses.");
			bool userDone = false;
			bool amountObtained = false;
			double amount = 0;
			string description = "";

			while (!userDone)
			{
				// Obtained user input for amount
				Console.WriteLine("Enter an amount.");
				string userEnteredAmount = Console.ReadLine();
				if (!amountObtained && double.TryParse(userEnteredAmount, out amount))
				{
					Console.WriteLine($"Thank you; you entered {userEnteredAmount}");
					// Obtain user input for description
					Console.WriteLine("Enter a description.");
					description = Console.ReadLine();
				}
				Dictionary<string, object> newExpense = new Dictionary<string, object>{
					{ "Amount", amount},
					{ "Description", description}

				};
				expenses.Add(newExpense);

				string addAnotherExpense = Console.ReadLine();

				if (!(addAnotherExpense == "Y" || addAnotherExpense == "y"))
				{
					userDone = true;
				}
			}
		}

		public static void displayExpenses()
		{

			Console.WriteLine("Here are your expenses:");
			foreach (var expense in expenses.SelectMany(exp => exp))
			{
				Console.WriteLine($"{expense.Key}: {expense.Value}");
			}
		}
	}
}