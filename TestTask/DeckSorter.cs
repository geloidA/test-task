using System;
using System.Collections.Generic;
using System.Linq;
using Shuffler;

namespace DeckSorter
{
    public class DeckSorter
    {
        private readonly Dictionary<string, Deck> orderedDecks;
        private readonly Dictionary<string, Deck> shuffledDecks;
        private readonly IShuffleStrategy shuffleStrategy;

        public IEnumerable<string> DeckNames
        {
            get
            {
                foreach (var deckName in orderedDecks)
                    yield return deckName.Key;
            }
        }

        public DeckSorter(IShuffleStrategy shuffleStrategy)
        {
            orderedDecks = new Dictionary<string, Deck>();
            shuffledDecks = new Dictionary<string, Deck>();
            this.shuffleStrategy = shuffleStrategy;
        }

        public void CreateDeck(string name)
        {
            if (orderedDecks.ContainsKey(name))
                throw new Exception(name + "already exists");
            var deck = new Deck();
            orderedDecks[name] = deck;
        }

        public bool RemoveDeck(string name)
        {
            return orderedDecks.Remove(name) | shuffledDecks.Remove(name);
        }

        public void ShuffleDeck(string name)
        {
            if(!orderedDecks.ContainsKey(name))
                throw new KeyNotFoundException(name);
            var shuffledCards = orderedDecks[name].Cards.ToArray();
            shuffleStrategy.Shuffle(shuffledCards);
            shuffledDecks[name] = new Deck(shuffledCards);
        }

        public Deck GetOrderedDeck(string name)
        {
            if (!orderedDecks.ContainsKey(name))
                throw new KeyNotFoundException(name);
            return orderedDecks[name];
        }

        public Deck GetShuffledDeck(string name)
        {
            if (!orderedDecks.ContainsKey(name))
                throw new KeyNotFoundException(name);
            if (!shuffledDecks.ContainsKey(name))
                ShuffleDeck(name);
            return shuffledDecks[name];
        }
    }
}
