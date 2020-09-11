using System;
using AirportAssgnmnt.Models;

namespace AirportAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var airplane1 = new Airplane("ABC123");
            var airplane2 = new Airplane("DDD888");
            
            //Day1 Outputs
            airplane1.LoadPassengers(43);
            airplane1.TakeOff();
            airplane2.LoadPassengers(23);
            airplane1.Land();
            airplane1.UnloadPassengers();
            airplane2.TakeOff();
            airplane2.Land();
            airplane2.UnloadPassengers();

            //Day2 Assignment1 Outputs
            airplane1.MaxNumOfPassengers = 43;
            airplane1.LoadPassengers(10);
            airplane1.LoadPassengers(43);
            airplane1.Land();
            airplane1.TakeOff();
            airplane2.LoadPassengers(23);
            airplane1.Land();
            airplane1.UnloadPassengers();
            airplane2.TakeOff();
            airplane2.TakeOff();
            airplane2.Land();
            airplane2.UnloadPassengers();

            //Day2 Assignment2 Outputs
            var airport1 = new Airport("Eindhoven");
            airport1.AddAirplane("ABC123");
            airport1.AddAirplane("DDD888");
            airport1.AddAirplane("ODL345");
            airport1.printAll();
            airport1.ShowAvailableAirplanes();
            airplane1 = airport1.RequestPlane("ABC123");
            airplane1.LoadPassengers(133); 



        }
    }
}

