using NUnit.Framework;
using Shuffler;
using System;

namespace ShuffleAlgorithmsTests
{
    public class Tests
    {        
        void TestNotEqual(Array inputArray, IShuffleStrategy shuffleStrategy)
        {
            var clonedArray = (Array)inputArray.Clone();
            shuffleStrategy.Shuffle(clonedArray);
            Assert.AreNotEqual(clonedArray, inputArray);
        }

        void TestAreEqual(Array inputArray, IShuffleStrategy shuffleStrategy)
        {
            var clonedArray = (Array)inputArray.Clone();
            shuffleStrategy.Shuffle(clonedArray);
            Assert.AreEqual(inputArray, clonedArray);
        }

        [TestCase(1, 2, 3 ,4, 5)]
        [TestCase(1, 2)]
        public void SimpleShuffleTest(params int[] arr)
        {
            TestNotEqual(arr, new SimpleShuffle());
        }

        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(1, 2, 3)]
        public void ManualShuffleTest(params int[] arr)
        {
            TestNotEqual(arr, new ManualShuffle());
        }

        [TestCase(1)]
        public void ShuffleOneLengthArraySimple(params int[] arr)
        {
            TestAreEqual(arr, new SimpleShuffle());
        }

        [TestCase(1)]
        public void ShuffleOneLengthArrayManual(params int[] arr)
        {
            TestAreEqual(arr, new ManualShuffle());
        }

        [Test]
        public void ShuffleThrowException()
        {
            Assert.Throws(typeof(NullReferenceException), () => 
            {
                Array a = null;
                TestAreEqual(a, new ManualShuffle());
            });
        }
    }
}