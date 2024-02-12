using System.IO;

namespace Tick.App
{
    class Tick
    {

        Config config = new Config();
        Menu menu = new Menu();
        private bool active = true;
        public bool isPaused = false;

        public void ContentWrapper(Action func)
        {
            this.menu.GetCurrentView();
            func();
        }

        public void Run()
        {
            bool loop = true;
            while (loop)
            {

                this.menu.currentView = "Main Menu";
                this.menu.DisplayWelcomeMessage();
                this.ContentWrapper(this.menu.DisplayMenuView);

                Console.Write("Your choice: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        this.menu.currentView = "Choose Timer";
                        this.ContentWrapper(this.Option1);
                        break;
                    case "2":
                        Console.Clear();
                        this.menu.currentView = "Add Timer";
                        this.ContentWrapper(this.Option2);
                        break;
                    default:
                        break;
                }
            }
        }


        public void InputListener()
        {
            // TODO add switch case
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.KeyChar == 'p')
                {
                    this.isPaused = true;
                }
                else if (keyInfo.KeyChar == 'c')
                {
                    this.isPaused = false;
                }
            }
        }
        public static int GetUserInputInt()
        {
            bool success = false;
            int num;
            while (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Sorry, that input is invalid; you must enter a number: ");
            }
            return num;
        }
        public void AddNewTimer()
        {
            // Prompt user to add new timer
            Console.Write("Choose a name: ");
            string name = Console.ReadLine();

            Console.Write("Choose a session length (minutes): ");
            int sessionLength = Tick.GetUserInputInt();

            Console.Write("Choose a short break length (minutes): ");
            int shortBreakLength = Tick.GetUserInputInt();

            Console.WriteLine("Choose a long break length (minutes): ");
            int longBreakLength = Tick.GetUserInputInt();

            Console.WriteLine("Choose a long break interval: ");
            int longBreakInterval = Tick.GetUserInputInt();

            // Initialize new timer and add to confing 
            Timer timer = new Timer(name, sessionLength, shortBreakLength, longBreakLength, longBreakInterval);
            this.config.AddTimer(timer);

            Thread thread = new Thread(this.InputListener);

            Thread.Sleep(1000);
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine("Timer added succssfully!");
            Thread.Sleep(1000);
        }
        public void Option1()
        {
            List<Timer> timers = this.config.GetAllTimers();
            bool loop = true;
            while (loop)
            {
                if (File.Exists(this.config.path))
                {
                    if (timers.Count == 0)
                    {
                        Console.WriteLine("Uh-oh, it doesn't look like there are any timers in your configuration file...\nlet's go ahead and create one for you.\n\n");
                        this.AddNewTimer();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please choose a timer name:\n");
                        foreach (Timer t in timers)
                        {
                            Console.Write($"{t.name} - {t.countdowns[0].duration}, {t.countdowns[1].duration}, {t.countdowns[2].duration}");
                            // Since Countdown does not include the 'interval' field (only LongBreak does), you can't iterate over Countdowns to get to 'interval'; Instead, check if it's of type LongBreak.
                            if (t.countdowns[2] is LongBreak longBreak) { Console.WriteLine($"{longBreak.interval}\n"); } else { Console.WriteLine("TODO"); }

                            bool validTimer = false;
                            while (!validTimer)
                            {
                                string userInput = Console.ReadLine();
                                Timer chosenTimer = timers.FirstOrDefault(t => t.name == userInput);
                                if (chosenTimer == null)
                                {
                                    Console.WriteLine("Sorry, there is no timer with that name. Please enter a valid name.");
                                }
                                else
                                {
                                    validTimer = true;
                                    Console.Clear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
                loop = false;
            }
        }
        public void Option2()
        {
            int seconds = 2;
            bool timerOver = seconds <= 0;
            Thread inputThread = new Thread(this.InputListener);
            inputThread.Start();
            while (seconds >= 0)
            {
                if (!isPaused)
                {

                    // This effectively clears the screen. We move the cursor to the start of the line and then write over it. 
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write($"Elapsed Time: {seconds} seconds"); // Overwrite previous output

                    // Increment the timer and wait for 1 second
                    seconds--;

                }
                Thread.Sleep(1000);
            }

            Console.SetCursorPosition(0, Console.CursorTop);
        }
        public void Prompt1()
        {

        }
    }

}