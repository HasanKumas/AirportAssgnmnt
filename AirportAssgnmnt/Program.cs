using System;
using AirportAssgnmnt.Models;

namespace AirportAssignment
{
    class Program
    {
        static void Main(string[] args)
        {        
            var airport1 = new Airport("Eindhoven");
            airport1.ShowAirplanes();
            PeoplePlane airplane1 = (PeoplePlane)airport1.RequestPlane("ABC123");
            airplane1.Load(133);
            airplane1.TakeOff();
            airplane1.Load(5);
            airplane1.Land();
            airplane1.Unload();
            airport1.ShowAvailableAirplanes();
            CargoPlane airplane2 = (CargoPlane)airport1.RequestPlane("FF2134");
            airplane2.Load(25);
            airplane2.TakeOff();
            airplane2.Unload();
            airplane2.Land();
            airplane2.Unload();
            SpacePlane spaceAirplane = (SpacePlane)airport1.RequestPlane("SPC777");
            spaceAirplane.StartMotor();
            spaceAirplane.TakeOff();
            spaceAirplane.TakeOverMissile(5);

        }
    }
}

