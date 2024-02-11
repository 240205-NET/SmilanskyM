namespace Tick.App
{
    class Tick
    {

        Config config = new Config();
        private bool active = true;

        public void Run()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Welcome to Tick! The greatest Pomodoro CLI ever created.\n");

                Console.WriteLine("=============================");
                Console.WriteLine("========= MAIN MENU =========");
                Console.WriteLine("=============================\n");

                Console.WriteLine("Choose a number (1-5) from the options below:");
                Console.WriteLine();
                Console.WriteLine("1: Choose Timer");
                Console.WriteLine("2: Add Timer");
                Console.WriteLine("3: View Timers");
                Console.WriteLine("4: Edit Timer");
                Console.WriteLine("5: Delete Timer");


                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        this.Option1();
                        break;
                    default:
                        Console.WriteLine("That's not a 1!");
                        break;
                }
            }
        }
        public void Option1()
        {
            bool loop = true;
            while (loop)
            {

                List<Timer> timers;
                if (File.Exists(this.config.path))
                {
                    timers = this.config.GetAllTimers();
                    if (!timers.Any())
                    {
                        Console.WriteLine("Uh-oh, it doesn't look like there are any timers in your configuration file...\nlet's go ahead and create one for you.\n\n")
                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("")
                    }
                }
            }
        }
    }
}