using System;
using NUnit.Framework;
using Algorithms.V2.GcdImplementations;

namespace Algorithms.V2.Tests
{
    public class AlgorithmForManyNumbersTests
    {
        private readonly EuclidianAlgorithm euclidian = new EuclidianAlgorithm();
        private readonly SteinsAlgorithm stein = new SteinsAlgorithm();

        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(12, 60, ExpectedResult = 12)]
        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(10927782, 6902514, ExpectedResult = 846)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [TestCase(int.MaxValue, int.MinValue + 1, ExpectedResult = int.MaxValue)]
        public int GcdManyNumbersEuclidianTests_WithTwoNumbers(int a, int b) => euclidian.Calculate(a, b);

        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(0, 0, -1, ExpectedResult = 1)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        public int GcdManyNumbersEuclidianTests_WithThreeNumbers(int a, int b, int c) => euclidian.GcdManyNumbers(a, b, c);

        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(18, 3, 9, 6, ExpectedResult = 3)]
        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        public int GcdManyNumbersEuclidianTests_ManyNumbers(params int[] numbers) => euclidian.GcdManyNumbers(numbers);

        [Test]
        public void GcdManyNumbersEuclidianTest_WithTwoZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => euclidian.GcdManyNumbers(0, 0),
                "Two numbers cannot be 0 at the same time.");

        [Test]
        public void GcdManyNumbersEuclidianTest_WithAllZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => euclidian.GcdManyNumbers(0, 0, 0, 0, 0, 0, 0),
                "All numbers cannot be 0 at the same time.");

        [Test]
        public void GcdManyNumbersEuclidianTest_WithOneParameter_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => euclidian.GcdManyNumbers(24));

        [Test]
        public void GcdManyNumbersEuclidianTest_WithIntMinValue_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentException>(() => euclidian.GcdManyNumbers(25, int.MinValue));

        [TestCase(0, 1, 0, 0)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(18, 3, 9, 6)]
        [TestCase(-10, 35, 90, 55, -105)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        public void GcdManyNumbersEuclidianTests_WithTime(params int[] numbers)
        {
            _ = euclidian.GcdManyNumbers(out long time, numbers);
            Assert.That(time > 0);
        }

        [Test]
        public void GcdManyNumbersSteinTest_WithAllZeroNumbers_ThrowArgumentException() =>
           Assert.Throws<ArgumentException>(() => stein.GcdManyNumbers(0, 0),
               "All numbers cannot be 0 at the same time.");

        [Test]
        public void GcdManyNumbersSteinTest_WithOneParameter_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => stein.GcdManyNumbers(24));

        [Test]
        public void GcdManyNumbersSteinTest_WithIntMinValue_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentException>(() => stein.GcdManyNumbers(25, int.MinValue));

        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        public int GcdManyNumbersSteinTests_WithTwoNumbers(int a, int b) => stein.Calculate(a, b);

        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        public int GcdManyNumbersSteinTests_WithThreeNumbers(int a, int b, int c) => stein.GcdManyNumbers(a, b, c);

        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(18, 3, 9, 6, ExpectedResult = 3)]
        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        public int GcdManyNumbersSteinTests_ManyNumbers(params int[] numbers) => stein.GcdManyNumbers(numbers);

        [TestCase(0, 1, 0, 0)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(18, 3, 9, 6)]
        [TestCase(-10, 35, 90, 55, -105)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        public void GcdManyNumbersSteinTests_WithTime(params int[] numbers)
        {
            _ = stein.GcdManyNumbers(out long time, numbers);
            Assert.That(time > 0);
        }
    }
}