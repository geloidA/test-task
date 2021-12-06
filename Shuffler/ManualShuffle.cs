using System;

namespace Shuffler
{
    public class ManualShuffle : IShuffleStrategy
    {
        private const int ShuffleCount = 100;
        private Random rnd = new Random();

        public void Shuffle(Array sequence)
        {
            if (sequence.Length == 1)
                return;
            for (var i = 0; i < ShuffleCount; i++)
            {
                var index = GetRandomIndex(sequence);
                Swap(sequence, index);
            }
        }

        private int GetRandomIndex(Array sequence)
        {
            var index = sequence.Length / 2 + rnd.Next(-1, 2);
            return index < 0 || index > sequence.Length - 1 ? sequence.Length / 2 : index;
        }

        private void Swap(Array array, int separator)
        {
            var firstPart = array.CreateCopy(0, separator + 1);
            var secondPart = array.CreateCopy(separator + 1, array.Length - 1 - separator);

            firstPart.CopyTo(array, array.Length - 1 - separator);
            secondPart.CopyTo(array, 0);
        }
    }
}
