using System;
using Xunit;

public class IntersectionTests
{
    [Fact]
    public void TestIntersectionCreation()
    {
        TrafficLight trafficLight = new TrafficLight(1000);
        Intersection intersection = new Intersection(1, trafficLight);
        Assert.Equal(1, intersection.ID);
        Assert.Equal(trafficLight, intersection.TrafficLight);
    }

    [Fact]
    public void TestAddRoad()
    {
        TrafficLight trafficLight = new TrafficLight(1000);
        Intersection intersection = new Intersection(1, trafficLight);
        Road road = new Road(1, "Main Street", 100, null, null);
        intersection.AddRoad(road);
        Assert.Contains(road, intersection.ConnectedRoads);
    }

    [Fact]
    public void TestManageTraffic()
    {
        TrafficLight trafficLight = new TrafficLight(1000);
        Intersection intersection = new Intersection(1, trafficLight);
        Road road = new Road(1, "Main Street", 100, intersection, intersection);
        intersection.AddRoad(road);
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        road.AddVehicle(vehicle);
        intersection.ManageTraffic();
    }

    [Fact]
    public void TestUpdateTrafficLightState()
    {
        TrafficLight trafficLight = new TrafficLight(1000);
        Intersection intersection = new Intersection(1, trafficLight);
        intersection.UpdateTrafficLightState("Green");
        Assert.Equal("Green", intersection.TrafficLight.State);
    }

    [Fact]
    public void TestLogTrafficState()
    {
        TrafficLight trafficLight = new TrafficLight(1000);
        Intersection intersection = new Intersection(1, trafficLight);
        Road road = new Road(1, "Main Street", 100, intersection, intersection);
        intersection.AddRoad(road);
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        road.AddVehicle(vehicle);
        intersection.LogTrafficState();
    }
}
