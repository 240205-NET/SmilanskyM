using System.IO;

namespace Tick.App
{
    class Tick
    {

        readonly Config config = new Config();
        readonly Menu menu = new Menu();
        public bool isPaused = false;
        private volatile bool timerActive = true;
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

            //Thread thread = new Thread(this.InputListener);

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
                if (timer.currentMode == "Session")
                {
                    timer.currentDuration = timer.countdowns[0].duration;
                    while (timer.currentDuration >= 0)
                    {
                        if (!this.timerActive)
                        {
                            Console.Clear();
                            return;
                        }
                        if (!timer.paused)
                        {
                            this.menu.DisplayTimerState(timer);
                            timer.currentDuration--;
                        }
                        Thread.Sleep(1000);
                    }
                    if (timer.longBreakCounter == 0)
                    {
                        timer.currentMode = "Long Break";
                        timer.longBreakInterval = 0;
                    }
                    else
                    {
                        timer.currentMode = "Short Break";
                    }
                    Console.Clear();
                }

                if (timer.currentMode == "Short Break")
                {
                    timer.currentDuration = timer.countdowns[1].duration;
                    while (timer.currentDuration >= 0)
                    {
                        if (!this.timerActive)
                        {
                            Console.Clear();
                            return;
                        }
                        if (!timer.paused)
                        {
                            this.menu.DisplayTimerState(timer);
                            timer.currentDuration--;

                        }
                        Thread.Sleep(1000);
                    }
                    timer.longBreakCounter--;
                    timer.currentMode = "Session";
                    Console.Clear();
                }
                if (timer.currentMode == "Long Break")
                {
                    timer.longBreakCounter = 4;
                    timer.currentDuration = timer.countdowns[2].duration;
                    while (timer.currentDuration >= 0)
                    {
                        if (!this.timerActive)
                        {
                            Console.Clear();
                            return;
                        }
                        if (!timer.paused)
                        {
                            this.menu.DisplayTimerState(timer);
                            timer.currentDuration--;

                        }
                        Thread.Sleep(1000);
                    }
                    timer.currentMode = "Session";
                    Console.Clear();
                }
            }
        }
    }
}