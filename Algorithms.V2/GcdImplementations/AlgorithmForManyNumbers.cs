using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Algorithms.V2.GcdImplementations;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.GcdImplementations
{
    /// <summary>Provides extension method's.</summary>
    public static class AlgorithmForManyNumbers
    {
        /// <summary>Calculates GCD of two numbers.</summary>
        /// <param name="algorithm">Algorithm.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="ticks">Method's execution time.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public static int GcdManyNumbers(this IAlgorithm algorithm, int first, int second, out long ticks)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            Validation(first, second);
            var timer = new Stopwatch();
            timer.Start();
            int result = algorithm.Calculate(first, second);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        /// <summary>Calculates GCD of three numbers.</summary>
        /// <param name="algorithm">Algorithm.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int GcdManyNumbers(this IAlgorithm algorithm, int first, int second, int third)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            Validation(first, second, third);
            int temporaryResult = algorithm.Calculate(first, second);
            return algorithm.Calculate(temporaryResult, third);
        }

        /// <summary>Calculates GCD of three numbers.</summary>
        /// <param name="algorithm">Algorithm.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <param name="ticks">Method's execution time.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public static int GcdManyNumbers(this IAlgorithm algorithm, int first, int second, int third, out long ticks)
        {
            Validation(first, second, third);
            var timer = new Stopwatch();
            timer.Start();
            int result = algorithm.GcdManyNumbers(first, second, third);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        /// <summary>Calculates GCD of many numbers.</summary>
        /// <param name="algorithm">Algorithm.</param>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of many numbers.</returns>
        public static int GcdManyNumbers(this IAlgorithm algorithm, params int[] numbers)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            Validation(numbers);

            int[] gcdsArray = numbers[..];
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

        /// <summary>Calculates GCD of many numbers.</summary>
        /// <param name="algorithm">Algorithm.</param>
        /// <param name="ticks">Method's execution time.</param>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of many numbers.</returns>
        public static int GcdManyNumbers(this IAlgorithm algorithm, out long ticks, params int[] numbers)
        {
            Validation(numbers);
            var timer = new Stopwatch();
            timer.Start();
            int result = algorithm.GcdManyNumbers(numbers);
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
    }
}
