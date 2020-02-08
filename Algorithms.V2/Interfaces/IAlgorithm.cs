namespace Algorithms.V2.Interfaces
{
    /// <summary>Provides functionality to calculate specified algorithm.</summary>
    public interface IAlgorithm
    {
        /// <summary>Calculates an algorithm for two numbers.</summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns calculation result of algorithm.</returns>
        int Calculate(int first, int second);
    }
}