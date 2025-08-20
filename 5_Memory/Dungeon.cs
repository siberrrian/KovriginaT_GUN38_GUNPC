using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Memory
{
    public struct Room
    {
        public Unit unit;
        public Weapon weapon;
        public Room(Unit unit, Weapon weapon)
        {
            this.unit = unit;
            this.weapon = weapon;
        }
    }

    public class Dungeon
    {
        public Room[] rooms;
        public Dungeon()
        {
            rooms = new Room[]
            {
                new Room(new Unit("Unit1"), new Weapon("Weapon1")),
                new Room(new Unit("Unit2"), new Weapon("Weapon2")),
                new Room(new Unit("Unit3"), new Weapon("Weapon3")),
                new Room(new Unit("Unit4"), new Weapon("Weapon4"))
            };
        }

        public void ShowRooms()
        {
            for(int i = 0; i < rooms.Length; i++)
            {
                Room room = rooms[i]; 
                Console.WriteLine("Unit of room " + (i+1) + " " + room.unit.Name);
                Console.WriteLine("Weapon of room " + (i+1) + " " + room.weapon.Name);
                Console.WriteLine("—");
            }
        }
    }
}
