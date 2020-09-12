using System;
using System.Collections.Generic;
using System.Text;

namespace AirportAssgnmnt.Models
{
    class CargoPlane : Airplane, Propellor
    {
        public int MaxAmountOfCargo { get; private set; }
        private int currentAmountOfCargo;

        public CargoPlane(string planeIdentification) : base(planeIdentification)
        {
            Type = AirplaneTypes.CARGO;
            MaxAmountOfCargo = 20;
        }
        public override void Load(int amountOfCargo)
        {
            if(IsCurrentlyFlying)
            {
                Console.WriteLine("Cargo plane cannot be loaded while flying");
                return;
            }

            if (currentAmountOfCargo + amountOfCargo > MaxAmountOfCargo)
            {
                var loaded = MaxAmountOfCargo - currentAmountOfCargo;
                var unloaded = amountOfCargo - loaded;
                Console.WriteLine($"Airplane {PlaneIdentification} charges {loaded} tons cargo, {unloaded} tons do not fit.");
                currentAmountOfCargo = MaxAmountOfCargo;
            }
            else            
            {
                currentAmountOfCargo += amountOfCargo;
                Console.WriteLine($"Airplane {PlaneIdentification} loads {amountOfCargo} tons cargo.");
            }
        }

        public override void Unload()
        {
            if(IsCurrentlyFlying)
            {
                Console.WriteLine("Cargo plane cannot be unloaded while flying");
                return;
            }
            Console.WriteLine($"Airplane {PlaneIdentification} unloads {currentAmountOfCargo} tons cargo.");
            currentAmountOfCargo = 0;
        }
        public override bool HasRooms()
        {
            if (currentAmountOfCargo < MaxAmountOfCargo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetRooms()
        {
            return MaxAmountOfCargo - currentAmountOfCargo;
        }

        public void TightenPropellor()
        {
            Console.WriteLine("The propellor has tightened.");
        }
    }
}
