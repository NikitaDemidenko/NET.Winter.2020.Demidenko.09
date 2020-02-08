using System;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    /// <summary>Euclidian algorithm.</summary>
    /// <seealso cref="Algorithms.V1.Interfaces.Algorithm" />
    internal class EuclidianAlgorithm : Algorithm
    {
        /// <summary>Calculates GCD of two numbers by Euclidian algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns calculation result of algorithm.</returns>
        protected override int Func(int first, int second)
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