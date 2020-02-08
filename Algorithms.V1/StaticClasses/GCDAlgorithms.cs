using System;
using System.Collections.Generic;
using System.Diagnostics;
using Algorithms.V1.GcdImplementations;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.StaticClasses
{
    /// <summary>Provides methods for calculating GCD.</summary>
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        /// <summary>Finds GCD of two numbers by Euclidean algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second)
            => Gcd(first, second, new EuclidianAlgorithm());

        /// <summary>Finds GCD of two numbers by Euclidean algorithm.</summary>
        /// <param name="milliseconds">Method's execution time.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclidianAlgorithm());

        /// <summary>Finds GCD of three numbers by Euclidean algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclidianAlgorithm());

        /// <summary>Finds GCD of three numbers by Euclidean algorithm.</summary>
        /// <param name="milliseconds">Method's execution time.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclidianAlgorithm());

        /// <summary>Finds GCD of many numbers by Euclidean algorithm.</summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of manny numbers.</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclidianAlgorithm(), numbers);

        /// <summary>Finds GCD of many numbers by Euclidean algorithm.</summary>
        /// <param name="milliseconds">Method's execution time.</param>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of manny numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclidianAlgorithm(), out milliseconds, numbers);

        #endregion

        #region Stein's Algorithms (API)

        /// <summary>Finds GCD of two numbers by Stein's algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByStein(int first, int second)
            => Gcd(first, second, new SteinsAlgorithm());

        /// <summary>Finds GCD of two numbers by Stein's algorithm.</summary>
        /// <param name="ticks">Method's execution time.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int FindGcdByStein(out long ticks, int first, int second)
            => Gcd(first, second, out ticks, new SteinsAlgorithm());

        /// <summary>Finds GCD of three numbers by Stein's algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByStein(int first, int second, int third)
            => Gcd(first, second, third, new SteinsAlgorithm());

        /// <summary>Finds GCD of three numbers by Stein's algorithm.</summary>
        /// <param name="ticks">Method's execution time.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int FindGcdByStein(out long ticks, int first, int second, int third)
            => Gcd(first, second, third, out ticks, new SteinsAlgorithm());

        /// <summary>Finds GCD of many numbers by Stein's algorithm.</summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of manny numbers.</returns>
        public static int FindGcdByStein(params int[] numbers)
            => Gcd(new SteinsAlgorithm(), numbers);

        /// <summary>Finds GCD of many numbers by Stein's algorithm.</summary>
        /// <param name="ticks">Method's execution time.</param>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of manny numbers.</returns>
        public static int FindGcdByStein(out long ticks, params int[] numbers)
            => Gcd(new SteinsAlgorithm(), out ticks, numbers);

        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, Algorithm algorithm)
        {
            Validation(first, second);
            return algorithm.Calculate(first, second);
        }

        private static int Gcd(int first, int second, out long ticks, Algorithm algorithm)
        {
            Validation(first, second);
            return algorithm.Calculate(first, second, out ticks);
        }

        private static int Gcd(int first, int second, int third, Algorithm algorithm)
        {
            Validation(first, second, third);

            int temporaryResult = algorithm.Calculate(first, second);
            return algorithm.Calculate(temporaryResult, third);
        }

        private static int Gcd(int first, int second, int third, out long ticks, Algorithm algorithm)
        {
            Validation(first, second, third);
            var timer = new Stopwatch();
            timer.Start();
            int result = Gcd(first, second, third, algorithm);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        private static int Gcd(Algorithm algorithm, params int[] numbers)
        {
            Validation(numbers);

            int[] gcdsArray = numbers[..];
            for (int i = 0; i < gcdsArray.Length - 1; i++)
            {
                if (gcdsArray[i] == 0)
                {
                    continue;
                }

                gcdsArray[i + 1] = algorithm.Calculate(gcdsArray[i + 1], gcdsArray[i]);
            }

            return gcdsArray[^1];
        }

        private static int Gcd(Algorithm algorithm, out long ticks, params int[] numbers)
        {
            Validation(numbers);
            var timer = new Stopwatch();
            timer.Start();
            int result = Gcd(algorithm, numbers);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        private static void Validation(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException("There are should be at least two parameters.");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == int.MinValue)
                {
                    throw new ArgumentException($"{int.MinValue} is out of range.");
                }
            }

            bool hasAllZeroes = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    hasAllZeroes = false;
                    break;
                }
            }

            if (hasAllZeroes)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }
        }

        #endregion

    }
}