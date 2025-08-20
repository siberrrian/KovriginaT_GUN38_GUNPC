using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _5_Memory
{
    public class Weapon
    {
        private Interval Damage;

        public Weapon() : this("Unknown weapon")
        {
        }

        public Weapon(string name) : this(name, 5, 10)
        { 
        }

        public Weapon(string name, int MinDamage, int MaxDamage)
        {
            Name = name;
            Durability = 1f;
            Damage = new Interval(MinDamage, MaxDamage);
        }

        public string Name { get; }
        public float Durability { get; }
        public int MinDamage
        {
            get { return Damage.Min; }
            set {
                if (value >= 0 && value <= 20) 
                {
                    Damage.Min = value;
                } 
            }
        }

        public int MaxDamage
        {
            get { return Damage.Max; }
            set
            {
                if (value >= 0 && value <= 20)
                {
                    Damage.Max = value;
                }
            }
        }

        public int GetDamage()
        {
            return ((MaxDamage + MinDamage) / 2);
        }
    }
}
