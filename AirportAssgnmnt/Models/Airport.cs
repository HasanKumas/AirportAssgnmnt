using System;
using System.Collections.Generic;

namespace AirportAssgnmnt.Models
{
    public class Airport
    {
        private string airportName;
        private List<Airplane> airplanes;

        public Airport(string airportName)
        {
            this.airportName = airportName;
            airplanes = new List<Airplane>();
        }
        public void AddAirplane(string name)
        {
            airplanes.Add(new Airplane(name));
        }
        public void printAll()
        {
            Console.WriteLine($"Aircrafts from airport {airportName}:");
            foreach (var airplane in airplanes)
            {
                Console.WriteLine("Airplane " + airplane.PlaneIdentification);
            }
        }
        public void ShowAvailableAirplanes()
        {
            foreach (var aplane in airplanes)
            {
                if (!aplane.IsCurrentlyFlying && aplane.HasRooms())
                {
                    Console.WriteLine($"Airplane {aplane.PlaneIdentification} is not flying, still room for {aplane.GetRooms()} passengers.");
                }
            }
        }
        public Airplane RequestPlane(string name)
        {
            foreach (var aplane in airplanes)
            {
                if (name == aplane.PlaneIdentification)
                {
                    if (!aplane.IsCurrentlyFlying && aplane.HasRooms())
                    {
                        Console.WriteLine($"Airplane {aplane.PlaneIdentification} requested. Is not flying, still room for {aplane.GetRooms()} passengers.");
                        return aplane;
                    }
                    else
                    {
                        Console.WriteLine($"Airplane {aplane.PlaneIdentification} is not available at the moment.");
                    }
                }
                else
                {
                    Console.WriteLine("There is no airplane with this identification.");
                }
            }
            return null;
        }
    }
}