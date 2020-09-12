using System;

namespace AirportAssgnmnt.Models
{
    class SpacePlane : Airplane, JetEngine, FlyOnMissile
    {
        public int MaxAmountOfRockets { get; private set; }
        private int currentAmountOfRockets;

        public SpacePlane(string planeIdentification) : base(planeIdentification)
        {
            Type = AirplaneTypes.SPACE;
            MaxAmountOfRockets = 10;
        }
        public override void Load(int amountOfRockets)
        {
            if (currentAmountOfRockets + amountOfRockets > MaxAmountOfRockets)
            {
                var loaded = MaxAmountOfRockets - currentAmountOfRockets;
                var unloaded = amountOfRockets - loaded;
                Console.WriteLine($"Airplane {PlaneIdentification} charges {loaded} rockets, {unloaded} do not fit.");
                currentAmountOfRockets = MaxAmountOfRockets;
            }
            else
            {
                currentAmountOfRockets += amountOfRockets;
                Console.WriteLine($"Airplane {PlaneIdentification} loads {amountOfRockets} rockets.");
            }
        }

        public override void Unload()
        {
            if (IsCurrentlyFlying)
            {
                Console.WriteLine("It cannot be unloaded while flying");
                return;
            }
            Console.WriteLine($"Airplane {PlaneIdentification} unloads {currentAmountOfRockets} rockets.");
            currentAmountOfRockets = 0;
        }
        public override bool HasRooms()
        {
            if (currentAmountOfRockets < MaxAmountOfRockets)
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
            return MaxAmountOfRockets - currentAmountOfRockets;
        }

        public void StartMotor()
        {
            Console.WriteLine("The starter motor has started.");
        }

        public void TakeOverMissile(int amount)
        {
            Console.WriteLine("Missiles are in range.");
            Load(amount);
        }
    }
}
