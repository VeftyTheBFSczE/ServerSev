using System.Collections.Generic;

public class Intersection
{
    public int ID { get; private set; }
    public List<Road> ConnectedRoads { get; private set; }
    public TrafficLight TrafficLight { get; private set; }

    public Intersection(int id, TrafficLight trafficLight)
    {
        ID = id;
        TrafficLight = trafficLight;
        ConnectedRoads = new List<Road>();
    }

    public void AddRoad(Road road)
    {
        ConnectedRoads.Add(road);
    }

    public void ManageTraffic()
    {
        // Řízení dopravy na křižovatce
        Console.WriteLine($"Managing traffic at intersection {ID}");
        foreach (var road in ConnectedRoads)
        {
            foreach (var vehicle in road.Vehicles)
            {
                if (TrafficLight.State == "Green")
                {
                    vehicle.LeaveIntersection();
                }
            }
        }
    }

    public void UpdateTrafficLightState(string newState)
    {
        TrafficLight.State = newState;
        Console.WriteLine($"Traffic light at intersection {ID} changed to {newState}");
    }

    public void LogTrafficState()
    {
        Console.WriteLine($"Logging traffic state at intersection {ID}");
        foreach (var road in ConnectedRoads)
        {
            foreach (var vehicle in road.Vehicles)
            {
                Console.WriteLine($"Vehicle {vehicle.ID} is on road {road.Name}");
            }
        }
    }
}
