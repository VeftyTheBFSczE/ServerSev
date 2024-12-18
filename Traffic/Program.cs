using System;

class Program
{
    static void Main(string[] args)
    {
        var config = Configuration.Load("config.json");

        var service = new TrafficSimulationService(config);

        var trafficLight1 = new TrafficLight(config.IntervalSemaforu);
        var trafficLight2 = new TrafficLight(config.IntervalSemaforu);
        var intersection1 = new Intersection(1, trafficLight1);
        var intersection2 = new Intersection(2, trafficLight2);

        var road1 = new Road(1, "First Street", config.DelkaSilnic, intersection1, intersection2);
        var road2 = new Road(2, "Second Street", config.DelkaSilnic, intersection2, intersection1);

        service.AddRoad(road1);
        service.AddRoad(road2);
        service.AddIntersection(intersection1);
        service.AddIntersection(intersection2);

        service.StartSimulation();
        service.PrintStatistics();
        service.LogSimulationState();
    }
}
