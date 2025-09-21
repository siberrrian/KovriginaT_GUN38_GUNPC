namespace Final_Task.CasinoMechanics.CasinoAttributes
{
    public struct Card
    {
        private readonly CardSuits _suit;
        private readonly CardValues _cardValue;
        public readonly CardSuits Suit => _suit;
        public readonly CardValues Value => _cardValue;

        public Card(CardSuits suit, CardValues value)
        {
            _suit = suit;
            _cardValue = value;
        }

    }
}
