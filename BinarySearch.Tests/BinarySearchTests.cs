namespace BinarySearch.Tests
{
    using System;
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

                if (array.BinarySearch(array[rng.Next(0, array.Length)]) == null)
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

                if (array.BinarySearch(-2 * SIZE) != null)
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

                if (array.BinarySearch(2 * SIZE) != null)
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

                if (array.BinarySearch(array[rng.Next(0, array.Length)], Comparison) == null)
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

                if (array.BinarySearch(array[rng.Next(0, array.Length)], Comparer<int>.Create(Comparison)) == null)
                {
                    Assert.Fail($"Test #{i} failed.");
                }
            }

            int Comparison(int x, int y) => x < y ? -1 :
                                            x > y ?  1 : 0;
        }

        [Test]
        public void BinarySearchIComparer_NullArray_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearchExtension.BinarySearch(null, 1, Comparer<int>.Create((a, b) => 1)));
        }

        [Test]
        public void BinarySearchIComparable_NullArray_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearchExtension.BinarySearch(null, 1));
        }

        [Test]
        public void BinarySearchDelegate_NullArray_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearchExtension.BinarySearch(null, 1, (a, b) => 1));
        }

        [Test]
        public void BinarySearchIComparer_NullElement_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => new string[1].BinarySearch((string)null, Comparer<string>.Create((a, b) => 1)));
        }

        [Test]
        public void BinarySearchIComparable_NullElement_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => new string[1].BinarySearch(null));
        }

        [Test]
        public void BinarySearchDelegate_NullElement_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => new string[1].BinarySearch(null, (a, b) => 1));
        }

        [Test]
        public void BinarySearchIComparer_NoComparer_ThrowsInvalidOperationExc()
        {
            Assert.Throws<InvalidOperationException>(() => new object[0].BinarySearch(1));
        }

        [Test]
        public void BinarySearchDelegate_NullDelegate_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => new int[1].BinarySearch(1, (Comparison<int>)null));
        }
    }
}
