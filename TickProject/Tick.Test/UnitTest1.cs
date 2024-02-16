namespace Tick.Test;
using System;
using System.IO;
using System.Xml.Serialization;
using Tick.App;


public class UnitTest1
{
    // This test deletes timers.xml before the other tests are executed
    // This ensures that the rest of the tests (the ones that interact with timers.xml) are normalized in their execution
    [Fact]
    public void TickApp_DeleteXmlToNormalizeTesting_Works()
    {
        if (File.Exists("timers.xml"))
        {
            File.Delete("timers.xml");
        }
        Assert.Equal(false, File.Exists("timers.xml"));
    }

    [Fact]
    public void InputManager_GetInt()
    {
        // We need a newline because it's sent to stdin when enter is pressed
        var input = "4\n";
        // This simulates an input to Console.ReadLine() (thank you, class)
        Console.SetIn(new StringReader(input));
        var actual = InputManager.GetInt();
        Assert.Equal(4, actual);
    }
    [Fact]
    public void Timer_CreateTimer_Works()
    {
        var actual = new Timer("Test Timer");
        Assert.IsType<Timer>(actual);
        Assert.Equal("Test Timer", actual.name);
    }

    [Fact]
    public void Menu_DisplayWelcomeMessage_Works()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);
        Menu menu = new Menu();
        menu.DisplayWelcomeMessage();

        Assert.Equal("Welcome to Tick! A Pomodoro timer for the Console.\n\r\n", writer.ToString());
    }

    [Fact]
    public void Timer_AddTimer_Works()
    {
        Timer timer = new Timer("Test Timer");
        Config config = new Config();
        config.AddTimer(timer);
        List<Timer> timers;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
        using (TextReader reader = new StreamReader(@"./timers.xml"))
        {
            timers = (List<Timer>)serializer.Deserialize(reader);
        }
        Timer addedTimer = timers.Find(t => t.name == "Test Timer");
        Assert.Equal("Test Timer", addedTimer.name);
    }



    [Fact]
    public void Menu_FormatTime_Works()
    {
        string formattedString = Menu.FormatTime(120);
        Assert.Equal("02:00", formattedString);
    }

    [Fact]
    public void Menu_DisplayTimerPaused_WorksWhenPaused()
    {
        Timer timer = new Timer("Test Timer");
        timer.paused = true;
        var actual = Menu.DisplayTimerPaused(timer);
        Assert.Equal("(paused)", actual);
    }


    [Fact]
    public void Menu_DisplayTimerPaused_WorksWhenActive()
    {

        Timer timer = new Timer("Test Timer");
        var actual = Menu.DisplayTimerPaused(timer);
        Assert.Equal("        ", actual);
    }

    [Fact]
    public void Menu_GetCurrentView_Works()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);
        Menu menu = new Menu();
        menu.GetCurrentView();
        Assert.Equal($"+++++++++++++++++++++++++\r\n {menu.currentView}\r\n+++++++++++++++++++++++++\n\r\n", writer.ToString());
    }
    [Fact]
    public void Timer_GetAllTimers_Works()
    {
        Timer timer1 = new Timer("Test Timer 1");
        Timer timer2 = new Timer("Test Timer 2");

        Config config = new Config();

        config.AddTimer(timer1);
        config.AddTimer(timer2);

        List<Timer> allTimers = config.GetAllTimers();
        Assert.Equal("Test Timer 1", allTimers[0].name);
        Assert.Equal("Test Timer 2", allTimers[1].name);
        Assert.Equal(2, allTimers.Count);
    }
    [Fact]
    public void Timer_RemoveTimer_Works()
    {
        Timer timer = new Timer("Test Timer");
        Config config = new Config();
        config.AddTimer(timer);
        config.RemoveTimer(timer.name);
        List<Timer> allTimers = config.GetAllTimers();
        Assert.Equal(0, allTimers.Count);
    }
}