﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirportAssgnmnt.Models
{
    public class PeoplePlane : Airplane, JetEngine
    {
        public int MaxNumOfPassengers { get; private set; }
        private int currentNumOfPassengers;

        public PeoplePlane(string planeIdentification) : base(planeIdentification)
        {
            Type = AirplaneTypes.PEOPLE;
            MaxNumOfPassengers = 100;
        }
        /*loads the plane with the specified amount by 
         *checking if the current load exceeds the max load 
         *and the plane has landed*/
        public override void Load(int numOfPassengers)
        {
            if (IsCurrentlyFlying)
            {
                Console.WriteLine("People plane cannot be loaded while flying");
                return;
            }
            if (currentNumOfPassengers + numOfPassengers > MaxNumOfPassengers)
            {
                var loaded = MaxNumOfPassengers - currentNumOfPassengers;
                var unloaded = numOfPassengers - loaded;
                Console.WriteLine($"Airplane {PlaneIdentification} charges {loaded} passengers, {unloaded} do not fit.");
                currentNumOfPassengers = MaxNumOfPassengers;
            }
            else
            {
                currentNumOfPassengers += numOfPassengers;
                Console.WriteLine($"Airplane {PlaneIdentification} loads {numOfPassengers} passengers.");
            }
        }
        //unloads the plane if it has landed
        public override void Unload()
        {
            if (IsCurrentlyFlying)
            {
                Console.WriteLine("People plane cannot be unloaded while flying");
                return;
            }
            Console.WriteLine($"Airplane {PlaneIdentification} unloads {currentNumOfPassengers} passengers.");
            currentNumOfPassengers = 0;
        }
        //checks if the plane has space for loading
        public override bool HasRooms()
        {
            if (currentNumOfPassengers < MaxNumOfPassengers)
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
            return MaxNumOfPassengers - currentNumOfPassengers;
        }

        public void StartMotor()
        {
            Console.WriteLine("The starter motor has started.");
        }
    }
}
