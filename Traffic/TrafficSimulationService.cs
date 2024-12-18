using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TrafficSimulationService
{
    public List<Road> Roads { get; private set; }
    public List<Intersection> Intersections { get; private set; }
    public Configuration Config { get; private set; }

    public TrafficSimulationService(Configuration config)
    {
        Roads = new List<Road>();
        Intersections = new List<Intersection>();
        Config = config;
    }

    public void AddRoad(Road road)
    {
        Roads.Add(road);
    }

    public void AddIntersection(Intersection intersection)
    {
        Intersections.Add(intersection);
    }

    public void SimulateTraffic()
    {
        Parallel.ForEach(Roads, road =>
        {
            foreach (var vehicle in road.Vehicles)
            {
                vehicle.Move();
            }
        });

        Parallel.ForEach(Intersections, intersection =>
        {
            intersection.ManageTraffic();
        });
    }

    public void StartSimulation()
    {
        for (int i = 0; i < Config.PocetVozidel; i++)
        {
            var vehicle = new Vehicle(i, "Car", 60);
            var road = Roads[i % Roads.Count];
            vehicle.CurrentRoad = road;
            road.AddVehicle(vehicle);
        }

        SimulateTraffic();
    }

    public void PrintStatistics()
    {
        Console.WriteLine("Traffic Simulation Statistics:");
        foreach (var road in Roads)
        {
            Console.WriteLine($"Road {road.Name} has {road.Vehicles.Count} vehicles.");
        }

        foreach (var intersection in Intersections)
        {
            Console.WriteLine($"Intersection {intersection.ID} has traffic light state {intersection.TrafficLight.State}.");
        }
    }

    public void LogSimulationState()
    {
        Logger.Log("Logging traffic simulation state...");
        foreach (var road in Roads)
        {
            Logger.Log($"Road {road.Name} has {road.Vehicles.Count} vehicles.");
        }

        foreach (var intersection in Intersections)
        {
            Logger.Log($"Intersection {intersection.ID} has traffic light state {intersection.TrafficLight.State}.");
        }
    }

    public void StopSimulation()
    {
        Console.WriteLine("Stopping simulation...");
        // Add logic to stop the simulation if needed
    }

    public void RestartSimulation()
    {
        Console.WriteLine("Restarting simulation...");
        StopSimulation();
        StartSimulation();
    }
}
