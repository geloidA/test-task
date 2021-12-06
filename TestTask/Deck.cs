using System;
using System.Collections.Generic;

namespace DeckSorter
{
    public class Deck
    {
        private readonly IReadOnlyList<(CardSuit, CardValue)> cards;

        public IEnumerable<(CardSuit, CardValue)> Cards
        {
            get
            {
                foreach (var card in cards)
                    yield return card;
            }
        }

        public Deck()// создаёт стандартную колоду карт (52 штуки)
        {
            var cards = new List<(CardSuit, CardValue)>();

            foreach (var suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                foreach (var value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                    cards.Add((suit, value));

            this.cards = cards;
        }

        public Deck(IReadOnlyList<(CardSuit, CardValue)> cards)
        {
            this.cards = cards;
        }
    }
}
