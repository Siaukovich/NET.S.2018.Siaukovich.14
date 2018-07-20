namespace FibonacciGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Class which methods generate Fibonacci sequence.
    /// </summary>
    public static class FibonacciGenerator
    {
        /// <summary>
        /// Generates first elements of the Fibonacci sequence.
        /// </summary>
        /// <param name="amount">
        /// Amount of Fibonacci number that will be generated.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if amount &lt;= 0.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Thrown if Fibonacci number exceeds 32 bit signed integer max value.
        /// </exception>
        public static IEnumerable<int> GenerateSequence(int amount)
        {
            int maxFibonacciNumber = GetMaxAmount(sizeof(int));
            if (amount <= 0 || amount > maxFibonacciNumber)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount), 
                    $"Amount of Fibonacci numbers cannot be less or equal 0 or greater than {maxFibonacciNumber}.");
            }

            return InnerGenerator();

            IEnumerable<int> InnerGenerator()
            {
                int a = 0;
                int b = 1;
                while (amount > 0)
                {
                    yield return a;

                    int temp = a;
                    a = b;
                    b = b + temp;

                    amount--;
                }
            }
        }

        /// <summary>
        /// Calculates number of the maximum Fibonacci number that can fit into provided size.
        /// </summary>
        /// <param name="variableSizeInBytes">
        /// Size in bytes.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetMaxAmount(int variableSizeInBytes)
        {
            // Calculating max Fibonacci number using next relationship:
            // Fn ~ PHI^n / sqrt(5)
            const int BITS_PER_BYTE = 8;
            const double PHI = 1.6180339875; // Golden section.

            double maxValue = Math.Pow(2, (BITS_PER_BYTE * variableSizeInBytes) - 1); // Minus one for sign bit.
            int n = (int)Math.Log((Math.Sqrt(5) * maxValue) + 0.5, PHI) + 1;

            return n;
        }
    }
}
