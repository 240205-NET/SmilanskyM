namespace Tick.Test;
using System;
using System.IO;
using System.Xml.Serialization;

using System.IO;
using Tick.App;
public class UnitTest1
{
    [Fact]
    public void StringToIntReturnsInt()
    {
        var actual = InputManager.StringToInt("4");

        Assert.IsType<int>(actual);
    }

    [Fact]
    public void Timer_CreateTimer_Works()
    {
        var actual = new Timer("Test Timer");
        Assert.IsType<Timer>(actual);
    }

    [Fact]
    public void Menu_DisplayWelcomeMessage_Works()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);
        Menu menu = new Menu();
        menu.DisplayWelcomeMessage();

        Assert.Equal("Welcome to Tick! The greatest Pomodoro CLI ever created.\n\r\n", writer.ToString());
    }

    [Fact]
    public void Timer_AddTimer_Works()
    {
        Timer timer = new Timer("Test Timer");
        Config config = new Config();
        config.AddTimer(timer);
        XmlSerializer serializer = new XmlSerializer(typeof(List<Timer>));
        List<Timer> timers;
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
        Assert.Equal("TIMER PAUSED", actual);
    }

    [Fact]
    public void Menu_DisplayTimerPaused_WorksWhenActive()
    {

        Timer timer = new Timer("Test Timer");
        var actual = Menu.DisplayTimerPaused(timer);
        Assert.Equal("TIMER ACTIVE", actual);
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
}