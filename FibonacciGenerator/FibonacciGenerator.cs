namespace FibonacciGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

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
        public static IEnumerable<BigInteger> GenerateSequence(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of Fibonacci numbers cannot be less or equal 0.");
            }

            return InnerGenerator();

            IEnumerable<BigInteger> InnerGenerator()
            {
                BigInteger a = 0;
                BigInteger b = 1;
                while (amount > 0)
                {
                    yield return a;

                    BigInteger temp = a;
                    a = b;
                    b = b + temp;

                    amount--;
                }
            }
        }
    }
}
