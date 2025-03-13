using System;
using System.Timers;


public class Clock
{
    private Timer timer;
    public event EventHandler OnTick;

    public Clock()
    {
        timer = new Timer(1000);
        timer.Elapsed += (sender, e) => OnTick?.Invoke(this, EventArgs.Empty);
    }
    public void Start()
    {
        timer.Start();
    }
}

public class Display
{
    public void Subscribe(Clock clock)
    {
        clock.OnTick += (sender, e) =>
        {
            Console.WriteLine($"Current time :{DateTime.Now.ToString("HH:mm:ss")}");
        };
    }
}

class Program
{
    static void Main()
    {
        Clock clock = new Clock();
        Display display = new Display();

        display.Subscribe(clock);

        clock.Start();
        Console.WriteLine("Press enter to stop...");
        Console.ReadLine();
    }
}
