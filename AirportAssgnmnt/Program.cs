using System;
using AirportAssgnmnt.Models;

namespace AirportAssignment
{
    class Program
    {
        static void Main(string[] args)
        {   
            /*create an airport which has 3 people plane,
            2 cargo plane and 1 space plane*/
            var airport1 = new Airport("Eindhoven");

            //list all the airplanes of the airport
            airport1.ShowAirplanes();

            //request airplanes and take some actions with them
            try
            {
                PeoplePlane airplane1 = (PeoplePlane)airport1.RequestPlane("ABC124");
                airplane1.Load(133);
                airplane1.TakeOff();
                airplane1.Load(5);
                airplane1.Land();
                airplane1.Unload();
                airport1.ShowAvailableAirplanes();
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
            try
            {
                CargoPlane airplane2 = (CargoPlane)airport1.RequestPlane("FF2134");
                airplane2.Load(25);
                airplane2.TakeOff();
                airplane2.Unload();
                airplane2.Land();
                airplane2.Unload();
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
            try
            {
                SpacePlane spaceAirplane = (SpacePlane)airport1.RequestPlane("SPC777");
                spaceAirplane.StartMotor();
                spaceAirplane.TakeOff();
                spaceAirplane.TakeOverMissile(5);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

