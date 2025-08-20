using System;
using System.Dynamic;
using System.Xml.Linq;

namespace _5_Memory
{
    public struct Interval
    {
        public int Min;
        public int Max;
        private Random random = new Random();
        public Interval(int min, int max)
        {
            if (min > max)
            {
                (min, max) = (max, min);
                Console.WriteLine("Incorrect input data for interval. The numbers are swapped.");
            }

            if (min < 0)
            {
                min = 0;
                Console.WriteLine("Incorrect input data for interval. Min forced to 0.");
            }

            if (max < 0)
            {
                max = 0;
                Console.WriteLine("Incorrect input data for interval. Max forced to 0.");
            }

            if (max == min)
            {
                max += 10;
                Console.WriteLine("Incorrect input data for interval. Max increased by 10.");
            }

            Max = max;
            Min = min;
        }
        public int Get()
        {
            return random.Next(Min, Max + 1);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();
        }
    }
}
