using System;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    /// <summary>Euclidian algorithm.</summary>
    /// <seealso cref="Algorithms.V3.Interfaces.IAlgorithm" />
    public class EuclidianAlgorithm : IAlgorithm
    {
        /// <summary>Calculates GCD of two numbers by Euclidian algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        public int Calculate(int first, int second)
        {
            int absFirst = Math.Abs(first);
            int absSecond = Math.Abs(second);
            return this.GcdEuclideanAlgorithm(absFirst, absSecond);
        }

        private int GcdEuclideanAlgorithm(int absFirs, int absSecond)
        {
            if (absFirs == 0)
            {
                return absSecond;
            }

            if (absSecond == 0)
            {
                return absFirs;
            }

            int remainder = absFirs - absSecond;
            while (remainder != 0)
            {
                int tmp = absSecond;
                absSecond = absFirs % absSecond;
                absFirs = tmp;
                remainder = absSecond;
            }

            return absFirs;
        }
    }
}