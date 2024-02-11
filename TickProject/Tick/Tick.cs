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
        public static int Text2Num(string numText)
        {
            int num;
            Int32.TryParse(numText, out num);
            return num;
        }
        public void Option1()
        {
            bool loop = true;
            while (loop)
            {

                List<Timer> timers;
                Timer timer;
                if (File.Exists(this.config.path))
                {
                    timers = this.config.GetAllTimers();
                    if (timers.Count <= 0)
                    {
                        Console.WriteLine("Uh-oh, it doesn't look like there are any timers in your configuration file...\nlet's go ahead and create one for you.\n\n");

                        Console.WriteLine("Choose a name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Choose a session length (minutes):");
                        string sessionLength = Console.ReadLine();

                        Console.WriteLine("Choose a short break length (minutes):");
                        string shortBreakLength = Console.ReadLine();

                        Console.WriteLine("Choose a long break length (minutes):");
                        string longBreakLength = Console.ReadLine();

                        Console.WriteLine("Choose a long break interval:");
                        string longBreakInterval = Console.ReadLine();

                        timer = new Timer(name, Text2Num(sessionLength), Text2Num(shortBreakLength), 3, 4);
                        timers.Add(timer);
                        this.config.SerializeToXml(timers, this.config.path);
                        Console.WriteLine("TIMER SUCCESSFULLY ADDED");
                        return;
                    }
                }
                else
                {

                    timer = new Timer("New Timer", 30, 10, 5, 4);
                    timers = new List<Timer>();
                    timers.Add(timer);
                    this.config.SerializeToXml(timers, this.config.path);
                    Console.WriteLine(timers);
                }
            }
        }
    }
}