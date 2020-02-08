using System;
using System.Diagnostics;

namespace Algorithms.V1.Interfaces
{
    /// <summary>Provides functionality to calculate specified algorithm.</summary>
    internal abstract class Algorithm
    {
        /// <summary>Calculates an algorithm for two numbers.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns calculation result of algorithm.</returns>
        public int Calculate(int first, int second)
        {
            return this.Func(first, second);
        }

        /// <summary>Calculates an algorithm for two numbers.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="ticks">Method's execution time.</param>
        /// <returns>Returns calculation result of algorithm.</returns>
        public int Calculate(int first, int second, out long ticks)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = this.Func(first, second);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        /// <summary>Specified algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns calculation result of algorithm.</returns>
        protected abstract int Func(int first, int second);
    }
}