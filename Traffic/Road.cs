using System.Collections.Generic;

public class Road
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Length { get; private set; }
    public List<Vehicle> Vehicles { get; private set; }
    public Intersection StartIntersection { get; private set; }
    public Intersection EndIntersection { get; private set; }

    public Road(int id, string name, int length, Intersection start, Intersection end)
    {
        ID = id;
        Name = name;
        Length = length;
        Vehicles = new List<Vehicle>();
        StartIntersection = start;
        EndIntersection = end;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
        Console.WriteLine($"Vehicle {vehicle.ID} added to road {Name}");
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
        Console.WriteLine($"Vehicle {vehicle.ID} removed from road {Name}");
    }

    public void CheckTraffic()
    {
        Console.WriteLine($"Checking traffic on road {Name}");
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine($"Vehicle {vehicle.ID} is on road {Name}");
        }
    }

    public int GetVehicleCount()
    {
        return Vehicles.Count;
    }
}
