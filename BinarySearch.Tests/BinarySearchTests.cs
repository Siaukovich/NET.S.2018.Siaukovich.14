namespace BinarySearch.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;
    using System.Linq;

    /// <summary>
    /// Class for testing binary search extension class.
    /// </summary>
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearchIComparable_Random1000SuccessfulTests()
        {
            const int SIZE = 1000;
            var rng = new Random(0);
            for (int i = 0; i < SIZE; i++)
            {
                int[] array = Enumerable.Range(0, SIZE).Select(v => rng.Next(v)).OrderBy(v => v).ToArray();

                if (!array.BinarySearch(array[rng.Next(0, array.Length)]))
                {
                    Assert.Fail($"Test #{i} failed.");
                }
            }
        }

        [Test]
        public void BinarySearchIComparable_Random1000UnsuccessfulTests_ItemLessThanMin()
        {
            const int SIZE = 1000;
            var rng = new Random(0);
            for (int i = 0; i < SIZE; i++)
            {
                int[] array = Enumerable.Range(0, SIZE).Select(v => rng.Next(-SIZE, SIZE)).OrderBy(v => v).ToArray();

                if (array.BinarySearch(-2 * SIZE))
                {
                    Assert.Fail($"Test #{i} failed.");
                }
            }
        }

        [Test]
        public void BinarySearchIComparable_Random1000UnsuccessfulTests_ItemGreaterThanMax()
        {
            const int SIZE = 1000;
            var rng = new Random(0);
            for (int i = 0; i < SIZE; i++)
            {
                int[] array = Enumerable.Range(0, SIZE).Select(v => rng.Next(-SIZE, SIZE)).OrderBy(v => v).ToArray();

                if (array.BinarySearch(2 * SIZE))
                {
                    Assert.Fail($"Test #{i} failed.");
                }
            }
        }

        [Test]
        public void BinarySearchDelegate_Random1000ValidTests()
        {
            const int SIZE = 1000;
            var rng = new Random(0);
            for (int i = 0; i < SIZE; i++)
            {
                int[] array = Enumerable.Range(0, SIZE).Select(v => rng.Next(v)).OrderBy(v => v).ToArray();

                if (!array.BinarySearch(array[rng.Next(0, array.Length)], Comparison))
                {
                    Assert.Fail($"Test #{i} failed.");
                }
            }

            int Comparison(int x, int y) => x < y ? -1 : 
                                            x > y ?  1 : 0;
        }

        [Test]
        public void BinarySearchIComparer_Random1000ValidTests()
        {
            const int SIZE = 1000;
            var rng = new Random(0);
            for (int i = 0; i < SIZE; i++)
            {
                int[] array = Enumerable.Range(0, SIZE).Select(v => rng.Next(v)).OrderBy(v => v).ToArray();

                if (!array.BinarySearch(array[rng.Next(0, array.Length)], Comparer<int>.Create(Comparison)))
                {
                    Assert.Fail($"Test #{i} failed.");
                }
            }

            int Comparison(int x, int y) => x < y ? -1 :
                                            x > y ?  1 : 0;
        }
    }
}
