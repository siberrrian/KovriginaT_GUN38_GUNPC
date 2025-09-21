using Final_Task.CasinoMechanics.CasinoAttributes;
using Final_Task.CasinoMechanics;

namespace Final_Task
{
    internal class Final_Task
    {
        static void Main(string[] args)
        {
            /* Dice dice1 = new Dice(1, 6);
             Dice dice2 = new Dice(7, 20);
             Console.WriteLine((dice2.Number, dice1.Number));
             Console.WriteLine((dice2.Number, dice1.Number));*/
             CasinoMechanics.Casino casino = new CasinoMechanics.Casino();
             casino.StartGame();
        }
    }
}
