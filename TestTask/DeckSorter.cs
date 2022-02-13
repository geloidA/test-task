using System;
using System.Collections.Generic;
using System.Linq;
using Shuffler;

namespace DeckSorter
{
    public class DeckSorter
    {
        private readonly Dictionary<string, Deck> decks;
        private readonly IShuffleStrategy shuffleStrategy;

        public IEnumerable<string> DeckNames
        {
            get
            {
                foreach (var deck in decks)
                    yield return deck.Key;
            }
        }

        public DeckSorter(IShuffleStrategy shuffleStrategy)
        {
            decks = new Dictionary<string, Deck>();
            this.shuffleStrategy = shuffleStrategy;
        }

        public void CreateDeck(string name)
        {
            if (decks.ContainsKey(name))
                throw new Exception(name + "already exists");
            var deck = new Deck();
            decks[name] = deck;
        }

        public bool RemoveDeck(string name)
        {
            return decks.Remove(name);
        }

        public void ShuffleDeck(string name)
        {
            if(!decks.ContainsKey(name))
                throw new KeyNotFoundException(name);
            var shuffledCards = decks[name].Cards.ToArray();
            shuffleStrategy.Shuffle(shuffledCards);
            decks[name] = new Deck(shuffledCards);
        }

        public Deck GetDeck(string name)
        {
            if (!decks.ContainsKey(name))
                throw new KeyNotFoundException(name);
            return decks[name];
        }
    }
}
