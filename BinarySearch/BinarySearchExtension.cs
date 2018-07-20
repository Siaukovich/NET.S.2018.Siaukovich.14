namespace BinarySearch
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Binary search.
    /// </summary>
    public static class BinarySearchExtension
    {
        /// <summary>
        /// Performs binary search over passed collection.
        /// </summary>
        /// <typeparam name="T">
        /// Type of searched object.
        /// </typeparam>
        /// <param name="collection">
        /// Collection that needs to be searched.
        /// </param>
        /// <param name="item">
        /// Item that needs to be found in collection.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if collection contains passed item, false otherwise.
        /// </returns>
        public static bool BinarySearch<T>(this IList<T> collection, T item) where T : IComparable<T> 
            => collection.BSearch(item.CompareTo);

        /// <summary>
        /// Performs binary search over passed collection using passed comparer.
        /// </summary>
        /// <param name="collection">
        /// Collection that needs to be searched.
        /// </param>
        /// <param name="item">
        /// Item that needs to be found in collection.
        /// </param>
        /// <param name="comparer">
        /// Comparer object for two elements of a given type.
        /// </param>
        /// <typeparam name="T">
        /// Type of searched object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if collection contains passed item, false otherwise.
        /// </returns>
        public static bool BinarySearch<T>(this IList<T> collection, T item, IComparer<T> comparer) =>
            collection.BSearch(x => comparer.Compare(item, x));

        /// <summary>
        /// Performs binary search over passed collection using passed comparison delegate.
        /// </summary>
        /// <param name="collection">
        /// Collection that needs to be searched.
        /// </param>
        /// <param name="item">
        /// Item that needs to be found in collection.
        /// </param>
        /// <param name="comparison">
        /// Comparison delegate of two elements of a given type.
        /// </param>
        /// <typeparam name="T">
        /// Type of searched object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if collection contains passed item, false otherwise.
        /// </returns>
        public static bool BinarySearch<T>(this IList<T> collection, T item, Comparison<T> comparison) =>
            collection.BSearch(x => comparison(item, x));

        /// <summary>
        /// The b search.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="compareWithItem">
        /// The compare with item.
        /// </param>
        /// <typeparam name="T">
        /// Type of searched object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if collection contains passed item, false otherwise.
        /// </returns>
        private static bool BSearch<T>(this IList<T> collection, Func<T, int> compareWithItem)
        {
            int leftIndex = 0;
            int rightIndex = collection.Count - 1;
            while (leftIndex <= rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                T middleItem = collection[middleIndex];
                int comparisonResult = compareWithItem(middleItem);
                if (comparisonResult < 0)
                {
                    rightIndex = middleIndex - 1;
                }
                else if (comparisonResult > 0)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
