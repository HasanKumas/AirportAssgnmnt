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
            airplanes.Add(new PeoplePlane("ABC123"));
            airplanes.Add(new PeoplePlane("DDD888"));
            airplanes.Add(new PeoplePlane("ODL345"));
            airplanes.Add(new CargoPlane("FF2134"));
            airplanes.Add(new CargoPlane("PLA166"));
            airplanes.Add(new SpacePlane("SPC777"));
        }
        public void AddAirplane(string name, AirplaneTypes type)
        {
            switch (type)
            {
                case AirplaneTypes.CARGO:
                    airplanes.Add(new CargoPlane(name));
                    break;
                case AirplaneTypes.SPACE:
                    airplanes.Add(new SpacePlane(name));
                    break;
                default:
                    airplanes.Add(new PeoplePlane(name));
                    break;
            }
        }
        public void ShowAirplanes()
        {
            Console.WriteLine($"Aircrafts from airport {airportName}:");
            foreach (var airplane in airplanes)
            {
                Console.WriteLine(airplane);
            }
        }
        public void ShowAvailableAirplanes()
        {
            Console.WriteLine("Available airplanes at the airport:");
            foreach (var aplane in airplanes)
            {
                if (!aplane.IsCurrentlyFlying && aplane.HasRooms())
                {
                    Console.WriteLine($"Airplane {aplane.PlaneIdentification} is not flying, still room for {aplane.GetRooms()}.");
                }
            }
        }
        public Airplane RequestPlane(string name)
        {
            var aplane = FindAirplane(name);
            if (!aplane.IsCurrentlyFlying && aplane.HasRooms())
            {
                switch (aplane.Type)
                {
                    case AirplaneTypes.CARGO:
                        Console.WriteLine($"Airplane {aplane.PlaneIdentification} requested. Is not flying, still room for {aplane.GetRooms()} tons of cargo.");
                        return aplane;
                    case AirplaneTypes.SPACE:
                        Console.WriteLine($"Airplane {aplane.PlaneIdentification} requested. Is not flying, still room for {aplane.GetRooms()} rockets.");
                        return aplane;
                    default:
                        Console.WriteLine($"Airplane {aplane.PlaneIdentification} requested. Is not flying, still room for {aplane.GetRooms()} passengers.");
                        return aplane;
                }
            }
            else
            {
                Console.WriteLine($"Airplane {aplane.PlaneIdentification} is not available at the moment.");
            }
            return null;
        }

        private Airplane FindAirplane(string name)
        {
            foreach (var aplane in airplanes)
            {
                if (name.Equals(aplane.PlaneIdentification))
                {
                    return aplane;
                }
            }
            return null;
        }
    }
}