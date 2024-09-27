using NUnit.Framework;
using NUnit.Framework.Legacy;
using FibonacciProjectForUnitTesting;

namespace Fibonacci_UnitTesting;

[TestFixture]
public class FibonacciTests
{
    [Test]
    public void Generate_ShallThrowAnException_ValueSmallerThanZero()
    {
        var inputZero = -1;
        ClassicAssert.Throws<ArgumentException>(() => Fibonacci.Generate(inputZero));
    }

    [Test]
    public void Generate_ShallThrowAnException_ValueLargerThanMaxValidNumber()
    {
        var inputLargerThanMax = 50;
        ClassicAssert.Throws<ArgumentException>(() => Fibonacci.Generate(inputLargerThanMax));
    }

    [TestCase(1, new int[] { 0 })]
    [TestCase(2, new int[] { 0, 1 })]
    [TestCase(3, new int[] { 0, 1, 1 })]
    [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
    [TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
    public void Generate_ShalProduceValidFibonacciSequence(int number, int[] expected)
    {
        IEnumerable<int> result = Fibonacci.Generate(number);
        ClassicAssert.AreEqual(expected, result);
    }

    [Test]
    public void Generate_ShallProduceSequenceWithLastNumber_1134903170_ForNEqualTo46()
    {
        var result = Fibonacci.Generate(46);
        var fibonacciNumber46 = 1134903170;

        ClassicAssert.AreEqual(fibonacciNumber46, result.Last());
    }

    [Test]
    public void GeneretaShallReturnNull_ForNEqualZero()
    {
        var result = Fibonacci.Generate(0);
        var expected = Enumerable.Empty<int>();

        ClassicAssert.AreEqual(expected, result);
    }
}
