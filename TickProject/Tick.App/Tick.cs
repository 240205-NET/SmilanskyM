using System.IO;
using System.Text;
namespace Tick.App
{
    class Tick
    {
        readonly Config config = new Config();
        readonly Menu menu = new Menu();
        public bool isPaused = false;
        public volatile bool timerActive = true;
        public void ContentWrapper(Action content)
        {
            this.menu.GetCurrentView();
            content();
        }

        public void Run()
        {


            bool loop = true;
            while (loop)
            {
                Console.Clear();
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
                        this.ContentWrapper(this.ChooseTimer);
                        break;
                    case "2":
                        Console.Clear();
                        this.menu.currentView = "Add Timer";
                        this.ContentWrapper(this.AddNewTimer);
                        break;
                    case "3":
                        Console.Clear();
                        this.menu.currentView = "View Timers";
                        this.ContentWrapper(this.ViewTimers);
                        break;
                    case "4":
                        Console.Clear();
                        this.menu.currentView = "Delete TImer";
                        this.ContentWrapper(this.DeleteTimer);
                        break;
                    case "5":
                        Console.Clear();
                        this.RunTimer(new Timer("Demo Timer"));
                        break;
                    default:
                        break;
                }
            }
        }

        public void DeleteTimer()
        {
            List<Timer> allTimers = this.config.GetAllTimers();

            string formattedTimers = this.menu.FormatTimerList(allTimers);

            bool deletingTimer = true;
            bool validTimer = false;

            while (deletingTimer)
            {
                Console.WriteLine("Choose a timer (by name) to delete: \n\n");
                Console.WriteLine(formattedTimers + "\n");
                Timer chosenTimer;
                while (!validTimer)
                {
                    Console.Write("\nYour choice: ");
                    string userInput = Console.ReadLine();
                    chosenTimer = allTimers.Find(t => t.name == userInput);
                    if (chosenTimer == null)
                    {
                        Console.WriteLine("Sorry, there is no timer with that name. Please enter a valid name.");
                    }
                    else
                    {
                        validTimer = true;
                        Console.WriteLine($"Timer with name {chosenTimer.name} deleted! Why would you do such a thing? :/ Oh well... taking you back to Main Menu...");
                        deletingTimer = false;
                    }
                }

            }
        }
        public void ViewTimers()
        {
            List<Timer> allTimers = this.config.GetAllTimers();
            string formattedTimers = this.menu.FormatTimerList(allTimers);
            bool viewingTimers = true;
            while (viewingTimers)
            {
                Console.WriteLine(formattedTimers);
                Console.WriteLine();
                Console.WriteLine("***PRESS (ESC} TO RETURN TO MAIN MENU***");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    viewingTimers = false;
                    return;
                }
            }

        }

        public void AddNewTimer()
        {
            // Prompt user to add new timer
            Console.Write("Choose a name: ");
            string name = Console.ReadLine();

            Console.Write("Choose a session length (minutes): ");
            int sessionLength = InputManager.GetInt();

            Console.Write("Choose a short break length (minutes): ");
            int shortBreakLength = InputManager.GetInt();

            Console.WriteLine("Choose a long break length (minutes): ");
            int longBreakLength = InputManager.GetInt();

            Console.WriteLine("Choose a long break interval: ");
            int longBreakInterval = InputManager.GetInt();

            // Initialize new timer and add to confing 
            Timer timer = new Timer(name, sessionLength, shortBreakLength, longBreakLength, longBreakInterval);
            this.config.AddTimer(timer);

            Thread.Sleep(1000);
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine("Timer added succssfully!");
            Thread.Sleep(1000);
        }
        public void ChooseTimer()
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
                            if (t.countdowns[2] is LongBreak longBreak) { Console.WriteLine($"{longBreak.interval}"); } else { Console.WriteLine("TODO"); }

                        }
                        bool validTimer = false;
                        while (!validTimer)
                        {
                            Console.Write("\nYour choice: ");
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
                                this.menu.currentView = "Run Timer";
                                this.RunTimer(chosenTimer);
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
        public void RunTimer(Timer timer)
        {
            this.timerActive = true;
            Thread keyListener = new Thread(() =>
            {
                while (this.timerActive)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.KeyChar == 'p' || keyInfo.KeyChar == 'P')
                    {
                        timer.paused = true;
                    }
                    else if (keyInfo.KeyChar == 'c' || keyInfo.KeyChar == 'C')
                    {
                        timer.paused = false;
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        this.timerActive = false;
                        return;
                    }
                }
            });

            keyListener.Start();
            while (this.timerActive)
            {
                this.HandleCurrentMode(timer);
                // if (timer.currentMode == "Session")
                // {
                //     timer.currentDuration = timer.countdowns[0].duration * 60; // mins to seconds
                //     timer.currentDuration = timer.countdowns[0].duration;
                //     while (timer.currentDuration >= 0)
                //     {
                //         if (!this.timerActive)
                //         {
                //             Console.Clear();
                //             return;
                //         }
                //         if (!timer.paused)
                //         {
                //             this.menu.DisplayTimerState(timer);
                //             timer.currentDuration--;
                //         }
                //         else
                //         {
                //             this.menu.DisplayTimerState(timer);
                //         }
                //         Thread.Sleep(1000);
                //     }
                //     if (timer.longBreakCounter == 0)
                //     {
                //         timer.currentMode = "Long Break";
                //         timer.longBreakInterval = 0;
                //     }
                //     else
                //     {
                //         timer.currentMode = "Short Break";
                //     }
                //     Console.Clear();
                // }

                // if (timer.currentMode == "Short Break")
                // {
                //     timer.currentDuration = timer.countdowns[1].duration * 60;
                //     while (timer.currentDuration >= 0)
                //     {
                //         if (!this.timerActive)
                //         {
                //             Console.Clear();
                //             return;
                //         }
                //         if (!timer.paused)
                //         {
                //             this.menu.DisplayTimerState(timer);
                //             timer.currentDuration--;

                //         }
                //         Thread.Sleep(1000);
                //     }
                //     timer.longBreakCounter--;
                //     timer.currentMode = "Session";
                //     Console.Clear();
                // }
                // if (timer.currentMode == "Long Break")
                // {
                //     timer.longBreakCounter = 4;
                //     timer.currentDuration = timer.countdowns[2].duration * 60;
                //     while (timer.currentDuration >= 0)
                //     {
                //         if (!this.timerActive)
                //         {
                //             Console.Clear();
                //             return;
                //         }
                //         if (!timer.paused)
                //         {
                //             this.menu.DisplayTimerState(timer);
                //             timer.currentDuration--;

                //         }
                //         Thread.Sleep(1000);
                //     }
                //     timer.currentMode = "Session";
                //     Console.Clear();

                // }
            }
        }

        public void HandleCurrentMode(Timer timer)
        {
            // Set the currentDuration based on the currentMode
            timer.currentDuration = timer.currentMode == "Session" ?
            timer.countdowns[0].duration * 60 :
            timer.currentMode == "Short Break" ?
            timer.countdowns[1].duration * 60 :
            timer.countdowns[2].duration * 60;
            while (timer.currentDuration >= 0)
            {
                if (!this.timerActive)
                {
                    // This occurs when the user presses 'ESC'
                    Console.Clear();
                    return;
                }
                if (!timer.paused)
                {
                    // If the timer isn't paused, display the updated timer state and elapse the timer
                    this.menu.DisplayTimerState(timer);
                    timer.currentDuration--;
                }
                else
                {
                    // Otherwise, just show the timer state
                    this.menu.DisplayTimerState(timer);
                }
                Thread.Sleep(1000);
            }
            // Once at this point, the timer is over and we set the next mode
            // 
            if (timer.currentMode == "Session")
            {
                // If it's time for a long break 
                if (timer.longBreakCounter == 0)
                {
                    // Set the current mode to Long Break and Reset the Long Break counter 
                    timer.currentMode = "Long Break";
                    timer.longBreakCounter = timer.longBreakInterval;
                }
                else
                {
                    // Otherwise, just move on to the Short Break
                    timer.currentMode = "Short Break";
                }
                // The Long Break Counter will always be decremented after a Session is over
                timer.longBreakCounter--;
            }
            else if (timer.currentMode == "Short Break" || timer.currentMode == "Long Break")
            {
                // Set the next mode to Session if it's one of the breaks 
                timer.currentMode = "Session";
            }
            Console.Clear();
        }
    }
}