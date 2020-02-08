using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    /// <summary>Provides methods to apply an algorithm for many numbers.</summary>
    /// <seealso cref="Algorithms.V3.Interfaces.IAlgorithm" />
    public class AlgorithmForManyNumbers : IAlgorithm
    {
        private readonly IAlgorithm algorithm;

        /// <summary>Initializes a new instance of the <see cref="AlgorithmForManyNumbers"/> class.</summary>
        /// <param name="algorithm">Algorithm.</param>
        /// <exception cref="ArgumentNullException">Thrown when algorithm is null.</exception>
        public AlgorithmForManyNumbers(IAlgorithm algorithm)
        {
            this.algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
        }

        /// <summary>Applies algorithm for two numbers.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns result of algorithm.</returns>
        public int Calculate(int first, int second)
        {
            return this.algorithm.Calculate(first, second);
        }

        /// <summary>Calculates GCD of three numbers.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public int GcdManyNumbers(int first, int second, int third)
        {
            this.Validation(first, second, third);
            int temporaryResult = this.algorithm.Calculate(first, second);
            return this.algorithm.Calculate(temporaryResult, third);
        }

        /// <summary>Calculates GCD of three numbers.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <param name="ticks">Method's execution time.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        public int GcdManyNumbers(int first, int second, int third, out long ticks)
        {
            this.Validation(first, second, third);
            var timer = new Stopwatch();
            timer.Start();
            int result = this.GcdManyNumbers(first, second, third);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        /// <summary>Calculates GCD of many numbers.</summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of many numbers.</returns>
        public int GcdManyNumbers(params int[] numbers)
        {
            this.Validation(numbers);

            int[] gcdsArray = numbers[..];
            for (int i = 0; i < gcdsArray.Length - 1; i++)
            {
                if (gcdsArray[i] == 0)
                {
                    continue;
                }

                gcdsArray[i + 1] = this.algorithm.Calculate(gcdsArray[i + 1], gcdsArray[i]);
            }

            return gcdsArray[^1];
        }

        /// <summary>Calculates GCD of many numbers.</summary>
        /// <param name="ticks">Method's execution time.</param>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Returns GCD of many numbers.</returns>
        public int GcdManyNumbers(out long ticks, params int[] numbers)
        {
            this.Validation(numbers);
            var timer = new Stopwatch();
            timer.Start();
            int result = this.GcdManyNumbers(numbers);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        private void Validation(params int[] numbers)
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
