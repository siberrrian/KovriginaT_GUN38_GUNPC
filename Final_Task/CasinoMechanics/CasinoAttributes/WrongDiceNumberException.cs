
namespace Final_Task.CasinoMechanics.CasinoAttributes
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int number, int min, int max)
        : base($"Incorrect number {number}. Enter number from {min} to {max}.")
        {
        }
    }
}
