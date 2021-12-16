using System;
using System.Collections.Generic;

namespace DeckSorter
{
    public class Deck
    {
        private readonly IReadOnlyList<Card> cards;

        public IEnumerable<Card> Cards
        {
            get
            {
                foreach (var card in cards)
                    yield return card;
            }
        }

        public Deck()// создаёт стандартную колоду карт (52 штуки)
        {
            var cards = new List<Card>();

            foreach (var suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                foreach (var value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                    cards.Add(new Card(suit, value));

            this.cards = cards;
        }

        public Deck(IReadOnlyList<Card> cards)
        {
            this.cards = cards;
        }
    }
}
