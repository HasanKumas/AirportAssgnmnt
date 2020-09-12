using System;
using System.Collections.Generic;
using System.Text;

namespace AirportAssgnmnt.Models
{
    public class CargoPlane : Airplane, Propellor
    {
        public int MaxAmountOfCargo { get; private set; }
        public int CurrentAmountOfCargo { get; private set; }

        public CargoPlane(string planeIdentification) : base(planeIdentification)
        {
            Type = AirplaneTypes.CARGO;
            MaxAmountOfCargo = 20;
        }
        /*loads the plane with the specified amount by 
         *checking if the current load exceeds the max load
         *and the plane has landed*/
        public override void Load(int amountOfCargo)
        {
            if(IsCurrentlyFlying)
            {
                Console.WriteLine("Cargo plane cannot be loaded while flying");
                return;
            }

            if (CurrentAmountOfCargo + amountOfCargo > MaxAmountOfCargo)
            {
                var loaded = MaxAmountOfCargo - CurrentAmountOfCargo;
                var unloaded = amountOfCargo - loaded;
                Console.WriteLine($"Airplane {PlaneIdentification} charges {loaded} tons cargo, {unloaded} tons do not fit.");
                CurrentAmountOfCargo = MaxAmountOfCargo;
            }
            else            
            {
                CurrentAmountOfCargo += amountOfCargo;
                Console.WriteLine($"Airplane {PlaneIdentification} loads {amountOfCargo} tons cargo.");
            }
        }
        //unloads the plane if it has landed
        public override void Unload()
        {
            if(IsCurrentlyFlying)
            {
                Console.WriteLine("Cargo plane cannot be unloaded while flying");
                return;
            }
            Console.WriteLine($"Airplane {PlaneIdentification} unloads {CurrentAmountOfCargo} tons cargo.");
            CurrentAmountOfCargo = 0;
        }
        //checks if the plane has space for loading
        public override bool HasRooms()
        {
            if (CurrentAmountOfCargo < MaxAmountOfCargo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //returns the amount of available spaces
        public override int GetRooms()
        {
            return MaxAmountOfCargo - CurrentAmountOfCargo;
        }

        public void TightenPropellor()
        {
            Console.WriteLine("The propellor has tightened.");
        }
    }
}
