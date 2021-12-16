using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckSorter
{
    public class Card
    {
        public readonly CardSuit Suit;
        public readonly CardValue Value;

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
