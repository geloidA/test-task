using Shuffler;

namespace DeckSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var deckSorter = new DeckSorter(new ManualShuffle());
            deckSorter.CreateDeck("first");
        }
    }
}
