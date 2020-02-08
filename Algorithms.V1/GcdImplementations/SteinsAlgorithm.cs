using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    /// <summary>Stein's algorithm.</summary>
    /// <seealso cref="Algorithms.V1.Interfaces.Algorithm" />
    internal class SteinsAlgorithm : Algorithm
    {
        /// <summary>Calculates GCD of two number by Stein's algorithm.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns calculation result of algorithm.</returns>
        protected override int Func(int first, int second)
        {
            int absFirst = Math.Abs(first);
            int absSecond = Math.Abs(second);
            return this.GcdSteinsAlgorithm(absFirst, absSecond);
        }

        private int GcdSteinsAlgorithm(int absFirst, int absSecond)
        {
            if (absFirst == 0)
            {
                return absSecond;
            }

            if (absSecond == 0)
            {
                return absFirst;
            }

            int shift;
            for (shift = 0; ((absFirst | absSecond) & 1) == 0; ++shift)
            {
                absFirst >>= 1;
                absSecond >>= 1;
            }

            while ((absFirst & 1) == 0)
            {
                absFirst >>= 1;
            }

            do
            {
                while ((absSecond & 1) == 0)
                {
                    absSecond >>= 1;
                }

                if (absFirst > absSecond)
                {
                    int t = absSecond;
                    absSecond = absFirst;
                    absFirst = t;
                }

                absSecond = absSecond - absFirst;
            }
            while (absSecond != 0);
            return absFirst << shift;
        }
    }
}
