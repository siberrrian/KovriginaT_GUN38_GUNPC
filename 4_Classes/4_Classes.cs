
using System;

namespace _4_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit unit1 = new Unit("Player1");
            Unit unit2 = new Unit("Player2");

            Console.WriteLine("Unit1 Name = " + unit1.Name);
            Console.WriteLine("Unit2 Name = " + unit2.Name);

            Console.WriteLine("Unit1 Health = " + unit1.Health);
            Console.WriteLine("Unit2 Health = " + unit2.Health);

            Console.WriteLine("Unit1 Armour = " + unit1.Armour);
            Console.WriteLine("Unit2 Armour = " + unit2.Armour);

            Console.WriteLine("Unit1 RealHealth = " + unit1.GetRealHealth());
            Console.WriteLine("Unit2 RealHealth = " + unit2.GetRealHealth());

            Console.WriteLine("Unit1 Damage = " + unit1.Damage);
            Console.WriteLine("Unit2 Damage = " + unit2.Damage);

            Console.WriteLine("Unit1 hit Unit2");
            if (!unit2.SetDamage(unit1.Damage))
            {
                Console.WriteLine("Unit2 is alive");
            }
            else
            {
                Console.WriteLine("Unit2 died");
            }
            Console.WriteLine("Unit2 Health = " + unit2.Health);
            Console.WriteLine("Unit2 RealHealth = " + unit2.GetRealHealth());

            Console.WriteLine("Unit1 hit Unit2 again");
            if (!unit2.SetDamage(unit1.Damage))
            {
                Console.WriteLine("Unit2 is alive");
            }
            else
            {
                Console.WriteLine("Unit2 died");
            }
            Console.WriteLine("Unit2 Health = " + unit2.Health);
            Console.WriteLine("Unit2 RealHealth = " + unit2.GetRealHealth());
        }
    }
}
