﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private List<int> closedRaces;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.closedRaces = new List<int>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                this.cars[id] = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "Show":
                this.cars[id] = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            default:
                break;

        }
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                this.races[id] = new CasualRace(length, route, prizePool);
                break;
            case "Drift":
                this.races[id] = new DriftRace(length, route, prizePool);
                break;
            case "Drag":
                this.races[id] = new DragRace(length, route, prizePool);
                break;
            default:
                break;
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int specialParam)
    {
        switch (type)
        {
            case "Circuit":

            default:
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.garage.ParkedCars.Contains(carId) && !closedRaces.Contains(raceId))
        {
            this.races[raceId]
                .Participants
                .Add(carId, this.cars[carId]);
        }
    }

    public string Start(int raceId)
    {
        if (this.races[raceId].Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        if (!closedRaces.Contains(raceId))
        {
            var result = races[raceId].ToString();

            this.races.Remove(raceId);
            this.closedRaces.Add(raceId);

            return result;
        }

        return null;
    }

    public void Park(int carId)
    {
        if (this.races.Values.Any(r => r.Participants.ContainsKey(carId)))
        {
            return;
        }

        this.garage.AddCar(carId);
    }

    public void Unpark(int carId)
    {
        this.garage.RemoveCar(carId);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        var parkedCarsIds = garage.ParkedCars;
        foreach (var carId in parkedCarsIds)
        {
            cars[carId].Tune(tuneIndex, addOn);
        }
    }
}

