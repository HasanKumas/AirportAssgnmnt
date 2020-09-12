using System;

namespace AirportAssgnmnt.Models
{
    public abstract class Airplane
    {
        public string PlaneIdentification { get; internal set; }        
        public bool IsCurrentlyFlying { get; private set; }

        public AirplaneTypes Type { get; protected set; }

        public Airplane(string planeIdentification)
        {
            PlaneIdentification = planeIdentification;
        }
        public abstract void Load(int amount);
        public abstract void Unload();
        public abstract bool HasRooms();
        public abstract int GetRooms();
        /*checks if the airplane is currently flying and 
         * performs take off action if not flying*/
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
        /*checks if the airplane is currently flying and 
        * performs land action if flying*/
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
        /*overrides the ToString method to
         * write airplane objects directly*/
        public override string ToString()
        {
            return $"{Type} plane {PlaneIdentification}";
        }
    }
}