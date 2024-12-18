public class Vehicle
{
    public int ID { get; private set; }
    public string Typ { get; private set; }
    public double Speed { get; set; }
    public Road CurrentRoad { get; set; }
    public Intersection CurrentIntersection { get; set; }

    public Vehicle(int id, string typ, double speed)
    {
        ID = id;
        Typ = typ;
        Speed = speed;
    }

    public void Move()
    {
        if (CurrentIntersection == null)
        {
            // Pohyb po silnici
            Console.WriteLine($"Vehicle {ID} is moving on road {CurrentRoad.Name}");
        }
        else
        {
            // Přechod přes křižovatku
            Console.WriteLine($"Vehicle {ID} is at intersection {CurrentIntersection.ID}");
        }
    }

    public void EnterIntersection(Intersection intersection)
    {
        CurrentIntersection = intersection;
        Console.WriteLine($"Vehicle {ID} entered intersection {intersection.ID}");
    }

    public void LeaveIntersection()
    {
        CurrentIntersection = null;
        Console.WriteLine($"Vehicle {ID} left the intersection");
    }

    public void ChangeSpeed(double newSpeed)
    {
        Speed = newSpeed;
        Console.WriteLine($"Vehicle {ID} changed speed to {Speed}");
    }

    public void Stop()
    {
        Speed = 0;
        Console.WriteLine($"Vehicle {ID} stopped");
    }

    public void Accelerate(double increment)
    {
        Speed += increment;
        Console.WriteLine($"Vehicle {ID} accelerated to {Speed}");
    }

    public void Decelerate(double decrement)
    {
        Speed = Math.Max(0, Speed - decrement);
        Console.WriteLine($"Vehicle {ID} decelerated to {Speed}");
    }
}
