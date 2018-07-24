namespace BinarySearch
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Binary search.
    /// </summary>
    public static class BinarySearchExtension
    {
        #region Public Methods

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
        /// <exception cref="ArgumentNullException">
        /// Thrown if collection, item or comparer is null.
        /// </exception>
        public static int? BinarySearch<T>(this IList<T> collection, T item, IComparer<T> comparer = null)
        {
            ThrowForNullListOrItem(collection, item);

            if (comparer == null)
            {
                if (!(item is IComparable<T>))
                {
                    throw new InvalidOperationException("Cannot compare items");
                }

                comparer = Comparer<T>.Default;
            }

            return collection.BSearch(x => comparer.Compare(item, x));
        }

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
        /// <exception cref="ArgumentNullException">
        /// Thrown if collection, item or comparison is null.
        /// </exception>
        public static int? BinarySearch<T>(this IList<T> collection, T item, Comparison<T> comparison)
        {
            ThrowForNullListOrItem(collection, item);
            ThrowForNull(comparison, nameof(comparison));

            return collection.BSearch(x => comparison(item, x));
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Binary search search.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="compareWithItem">
        /// Delegate that compares item to collection's element.
        /// Must return -1 if item if less than collection's element,
        /// 0 if they are equal,
        /// 1 if item is less than collection's element.
        /// </param>
        /// <typeparam name="T">
        /// Type of searched object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if collection contains passed item, false otherwise.
        /// </returns>
        private static int? BSearch<T>(this IList<T> collection, Func<T, int> compareWithItem)
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
                    return middleIndex;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if passed collection of item equal to null and throws exception if some of them is.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="T">
        /// Type of collections elements.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// Thrown if collection or item is null.
        /// </exception>
        private static void ThrowForNullListOrItem<T>(IList<T> collection, T item)
        {
            ThrowForNull(collection, nameof(collection));
            ThrowForNull(item, nameof(item));
        }

        /// <summary>
        /// Checks if passed item is equal to null and throws exception if it is.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="itemName">
        /// Item's name.
        /// </param>
        /// <typeparam name="T">
        /// Item's type.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// Thrown if collection or item is null.
        /// </exception>
        private static void ThrowForNull<T>(T item, string itemName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(itemName);
            }
        }

        #endregion
    }
}
