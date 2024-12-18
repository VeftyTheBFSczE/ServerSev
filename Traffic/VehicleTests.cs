using System;
using Xunit;

public class VehicleTests
{
    [Fact]
    public void TestVehicleCreation()
    {
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        Assert.Equal(1, vehicle.ID);
        Assert.Equal("Car", vehicle.Typ);
        Assert.Equal(60, vehicle.Speed);
    }

    [Fact]
    public void TestVehicleMove()
    {
        Road road = new Road(1, "Main Street", 100, null, null);
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        vehicle.CurrentRoad = road;
        vehicle.Move();
    }

    [Fact]
    public void TestVehicleEnterLeaveIntersection()
    {
        TrafficLight trafficLight = new TrafficLight(1000);
        Intersection intersection = new Intersection(1, trafficLight);
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        
        vehicle.EnterIntersection(intersection);
        Assert.Equal(intersection, vehicle.CurrentIntersection);

        vehicle.LeaveIntersection();
        Assert.Null(vehicle.CurrentIntersection);
    }

    [Fact]
    public void TestVehicleChangeSpeed()
    {
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        vehicle.ChangeSpeed(80);
        Assert.Equal(80, vehicle.Speed);
    }

    [Fact]
    public void TestVehicleStop()
    {
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        vehicle.Stop();
        Assert.Equal(0, vehicle.Speed);
    }

    [Fact]
    public void TestVehicleAccelerate()
    {
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        vehicle.Accelerate(20);
        Assert.Equal(80, vehicle.Speed);
    }

    [Fact]
    public void TestVehicleDecelerate()
    {
        Vehicle vehicle = new Vehicle(1, "Car", 60);
        vehicle.Decelerate(30);
        Assert.Equal(30, vehicle.Speed);
    }
}
