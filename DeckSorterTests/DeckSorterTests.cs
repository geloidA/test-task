using NUnit.Framework;
using Shuffler;
using System.Linq;
using System.Collections.Generic;

namespace DeckSorterTests
{
    public class Tests
    {
        static object[] shuffleMethods =
        {
            new ManualShuffle(),
            new SimpleShuffle()
        };

        [TestCaseSource(nameof(shuffleMethods))]
        public void ShuffleTest(IShuffleStrategy shuffleStrategy)
        {
            var deckSorter = new DeckSorter.DeckSorter(shuffleStrategy);
            Assert.AreEqual(0, deckSorter.DeckNames
                .ToList()
                .Count);
            deckSorter.CreateDeck("casual");
            deckSorter.ShuffleDeck("casual");
            Assert.AreEqual(1, deckSorter.DeckNames
                .ToList()
                .Count);

            var orderedDeck = deckSorter.GetOrderedDeck("casual");
            var shuffledDeck = deckSorter.GetShuffledDeck("casual");

            Assert.AreNotEqual(orderedDeck.Cards, shuffledDeck.Cards);
        }

        [Test]
        public void CreateDeckTest()
        {
            var deckSorter = new DeckSorter.DeckSorter(new SimpleShuffle());
            deckSorter.CreateDeck("test");
            Assert.AreEqual(1, deckSorter.DeckNames.Count());
            Assert.AreEqual("test", deckSorter.DeckNames.First());
        }

        [Test]
        public void GetDeckThrowsExceptionIfDeckNotExist()
        {
            var deckSorter = new DeckSorter.DeckSorter(new SimpleShuffle());
            Assert.Throws<KeyNotFoundException>(() => deckSorter.GetOrderedDeck("test"));
        }

        [Test]
        public void RemoveDeckTest()
        {
            var deckSorter = new DeckSorter.DeckSorter(new SimpleShuffle());
            deckSorter.CreateDeck("test");
            deckSorter.RemoveDeck("test");
            Assert.AreEqual(0, deckSorter.DeckNames
                .ToList()
                .Count);
        }
    }
}