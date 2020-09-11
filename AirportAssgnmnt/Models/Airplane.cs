using System;

namespace AirportAssgnmnt.Models
{
    public class Airplane
    {
        public string PlaneIdentification { get; set; }
        public bool IsCurrentlyFlying { get; set; }
        public int MaxNumOfPassengers { get; set; }
        private int currentNumOfPassengers;

        public Airplane(string planeIdentification)
        {
            PlaneIdentification = planeIdentification;
            MaxNumOfPassengers = 100;

        }
        public void LoadPassengers(int numOfPassengers)
        {
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

        public void UnloadPassengers()
        {
            Console.WriteLine($"Airplane {PlaneIdentification} unloads {currentNumOfPassengers} passengers.");
            currentNumOfPassengers = 0;
        }

        public void TakeOff()
        {
            if (IsCurrentlyFlying)
            {
                Console.WriteLine($"Airplane {PlaneIdentification} can not take off, because we are already flying.");
            }
            else
            {
                IsCurrentlyFlying = true;
                Console.WriteLine($"Airplane {PlaneIdentification} takes off.");
            }
        }

        public void Land()
        {
            if (!IsCurrentlyFlying)
            {
                Console.WriteLine($"Airplane {PlaneIdentification} can not land, because we are still on the ground.");
            }
            else
            {
                IsCurrentlyFlying = false;
                Console.WriteLine($"Airplane {PlaneIdentification} lands.");
            }
        }
        public bool HasRooms()
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

        public int GetRooms()
        {
            return MaxNumOfPassengers - currentNumOfPassengers;
        }
    }
}