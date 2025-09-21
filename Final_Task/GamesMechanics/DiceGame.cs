using Final_Task.CasinoMechanics.CasinoAttributes;
using System.Collections.Generic;

namespace Final_Task.GamesMechanics
{
    internal class DiceGame : CasinoGameBase
    {
        public List<Dice> dices = [];
        private int _cntDices;
        private int _minValue;
        private int _maxValue;

        public DiceGame(int cntDices, int minValue, int maxValue) 
        {
            _cntDices = cntDices;
            _minValue = minValue;
            _maxValue = maxValue;
            FactoryMethod();
        }

        public override void PlayGame()
        {
            int sumPlayer = 0;
            int sumComputer = 0;
            int currentValueDicePlayer;
            int currentValueDiceComputer;

            for (int i = 0; i < _cntDices; i++)
            {
                currentValueDicePlayer = dices[i].Number;
                sumPlayer += currentValueDicePlayer;
                currentValueDiceComputer = dices[i].Number;
                sumComputer += currentValueDiceComputer;
                Console.WriteLine($"Your dice roll: {currentValueDicePlayer}, Computer dice roll: {currentValueDiceComputer}");
            }
            Console.WriteLine($"Your dice roll total: {sumPlayer}, Computer dice roll total: {sumComputer}");

            if (sumPlayer > sumComputer)
            {
                OnWinInvoke();
            } else if (sumPlayer < sumComputer)
            {
                OnLooseInvoke();
            } else if (sumPlayer == sumComputer)
            {
                OnDrawInvoke();
            }
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _cntDices; i++)
            {
                dices.Add(new Dice(_minValue, _maxValue));
            }
        }
    }
}
