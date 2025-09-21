
using Final_Task.CasinoMechanics.CasinoAttributes;

namespace Final_Task.GamesMechanics
{
    internal class BlackjackGame : CasinoGameBase
    {
        private Queue<Card> _deck = [];
        public BlackjackGame(int cntCards) 
        {
            FactoryMethod();
        }
        public override void PlayGame()
        {
            int sumPlayer = 0;
            int sumComputer = 0;
            List<Card> cardsPlayer = [];
            List<Card> cardsComputer = [];

            cardsPlayer.Add(_deck.Dequeue());
            cardsComputer.Add(_deck.Dequeue());
            cardsPlayer.Add(_deck.Dequeue());
            cardsComputer.Add(_deck.Dequeue());
            sumPlayer = (int)cardsPlayer[0].Value + (int)cardsPlayer[1].Value;
            sumComputer = (int)cardsComputer[0].Value + (int)cardsComputer[1].Value;


            Console.WriteLine($"Your cards: {cardsPlayer[0].Suit} {cardsPlayer[0].Value}, {cardsPlayer[1].Suit} {cardsPlayer[1].Value}");
            Console.WriteLine($"Computer cards: {cardsComputer[0].Suit} {cardsComputer[0].Value}, {cardsComputer[1].Suit} {cardsComputer[1].Value}");
            
            while (sumComputer < 21 && sumPlayer < 21)
            {
                cardsPlayer.Add(_deck.Dequeue());
                cardsComputer.Add(_deck.Dequeue());
                sumPlayer += (int)cardsPlayer[cardsPlayer.Count - 1].Value;
                sumComputer += (int)cardsComputer[cardsComputer.Count - 1].Value;
                Console.WriteLine($"Your cards: {cardsPlayer[cardsPlayer.Count - 1].Suit} {cardsPlayer[cardsPlayer.Count - 1].Value}");
                Console.WriteLine($"Computer cards: {cardsComputer[cardsComputer.Count - 1].Suit} {cardsComputer[cardsComputer.Count - 1].Value}");
            }
            if ((sumComputer > 21 && sumPlayer > 21) || (sumComputer == 21 && sumPlayer == 21)) 
            {
                OnDrawInvoke();
            }
            else if (sumComputer <= 21)
            {
                OnLooseInvoke();
            }
            else if (sumPlayer <= 21)
            {
                OnWinInvoke();
            } 
            
        }

        protected override void FactoryMethod()
        {
            List<Card> cards = [];

            foreach (CardSuits cardSuit in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (CardValues cardValue in Enum.GetValues(typeof(CardValues)))
                {
                    cards.Add(new Card(cardSuit, cardValue));
                }
            }

            Shuffle(cards);
        }

        private void Shuffle(List<Card> cards)
        {
            Random rand = new Random();
            int card1, card2;
            Card tmp;
            for (int i = 0; i < 1000; i++)
            {
                card1 = rand.Next(0, cards.Count);
                card2 = rand.Next(0, cards.Count);
                if (card1 != card2)
                {
                    tmp = cards[card1];
                    cards[card1] = cards[card2];
                    cards[card2] = tmp;
                }

            }
            for (int i = 0; i < cards.Count; i++)
            {
                _deck.Enqueue(cards[i]);
            }
        }
    }
}
