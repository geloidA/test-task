using System;

namespace Shuffler
{
    public class SimpleShuffle : IShuffleStrategy
    {
        private Random rnd = new Random();
        public void Shuffle(Array sequence)
        {
            if (sequence.Length == 1)
                return;
            for (var i = sequence.Length - 1; i > 0; i--)
            {
                var j = rnd.Next(0, i + 1);
                var temp = sequence.GetValue(i);
                sequence.SetValue(sequence.GetValue(j), i);
                sequence.SetValue(temp, j);
            }
        }
    }
}
