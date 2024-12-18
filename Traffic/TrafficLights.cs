using System;
using System.Threading;

public class TrafficLight
{
    public string State { get; private set; }
    public int Interval { get; private set; }

    public TrafficLight(int interval)
    {
        Interval = interval;
        State = "Red";
    }

    public void ChangeState()
    {
        Task.Run(() =>
        {
            while (true)
            {
                switch (State)
                {
                    case "Red":
                        State = "Green";
                        break;
                    case "Green":
                        State = "Yellow";
                        break;
                    case "Yellow":
                        State = "Red";
                        break;
                }
                Console.WriteLine($"Traffic light changed to {State}");
                Thread.Sleep(Interval);
            }
        });
    }
}
