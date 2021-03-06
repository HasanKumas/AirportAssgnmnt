﻿using System;

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
        /*loads the plane with the specified amount by 
         * checking if the current load exceeds the max load*/
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
        //unloads the plane if it has landed
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
        //checks if the plane has space for loading
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
        //returns the amount of available spaces
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
