using AirportAssgnmnt.Exceptions;
using System;
using System.Collections.Generic;

namespace AirportAssgnmnt.Models
{
    public class Airport
    {
        private string airportName;
        private List<Airplane> airplanes;
        
        /*creates an airport with the specified name
         * adds 3 people, 2 cargo and 1 space plane to
         * the airplanes list by default
         * */
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
        /*adds an airplane to the airport
         *parameters:
         *name for the plane identification,
         *type for airplane type
         */
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
        //shows all the airplanes of the airport
        public void ShowAirplanes()
        {
            Console.WriteLine($"Aircrafts from airport {airportName}:");
            foreach (var airplane in airplanes)
            {
                Console.WriteLine(airplane);
            }
        }
        /*shows only available airplanes which 
         * has rooms for load and do not currently fly*/
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
        /*returns the requested airplane if available and
         * shows information about the requested plane*/
        public Airplane RequestPlane(string name)
        {
                var aplane = FindAirplane(name);
            try
            {
                if (aplane is null)
                    throw new NullReturnException();
            }
            catch(NullReturnException ex)
            {
                Console.WriteLine("A null is returned: " + ex);
                return null;
            }
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
                return null;
            }
        }
        //finds and returns requested airplane
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