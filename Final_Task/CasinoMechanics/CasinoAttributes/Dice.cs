namespace Final_Task.CasinoMechanics.CasinoAttributes
{
    public struct Dice
    {
        private int _min;
        private int _max;
        private Random random = new Random();

        public readonly int Number 
        { 
            get { 
                return random.Next(_min, _max+1);
            }
        }

        public Dice(int min, int max) 
        {
            if (max < min)
            {
                throw new ArgumentException("Maximum value cannot be less than minimum value.");
            }

            if (min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException(min, 1, int.MaxValue);
            }

            if (max < 1 || max > int.MaxValue)
            {
                throw new WrongDiceNumberException(max, 1, int.MaxValue);
            }

            _min = min;
            _max = max;
        }
    }
}
