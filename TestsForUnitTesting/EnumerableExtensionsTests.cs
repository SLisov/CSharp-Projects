using NUnit.Framework;
using NUnit.Framework.Legacy;
using UnitTesting;

namespace TestsForUnitTesting;

[TestFixture]
public class EnumerableExtensionsTests
{
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_ForEmptyCollection()
    {
        var input = Enumerable.Empty<int>();

        var result = input.SumOfEvenNumbers();

        ClassicAssert.AreEqual(0, result);
    }

    [Test]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumbersArePresent()
    {
        var input = new int[] { 1, 3, 3, 4, 6, 7 };

        var result = input.SumOfEvenNumbers();

        var expected = 10;
        var inputAsString = string.Join(", ", input);
        ClassicAssert.AreEqual(10, result, $"For input {inputAsString} " +
            $"the result shall be {expected} but it was {result}");
    }

    [TestCase(8)]
    [TestCase(-8)]
    [TestCase(6)]
    [TestCase(0)]
    public void SumOfEvenNumbers_ShallReturnValueOFTheOnlyItem_IfItIsEven(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        ClassicAssert.AreEqual(number, result);
    }

    [TestCase(1)]
    [TestCase(-7)]
    [TestCase(33)]
    public void SumOfEvenNumbers_ShallReturnZeroIfOnlyNumbersInInputIsOdd(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        ClassicAssert.AreEqual(0, result);
    }

    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumbers(IEnumerable<int> input, int expected)
    {
        var result = input.SumOfEvenNumbers();

        ClassicAssert.AreEqual(expected, result);
    }

    private static IEnumerable<object> GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
            new object[] { new int[] { 1, 4, 3, 6,7,9},10 },
            new object[] { new List<int> { 1,3,5,11,35,40,55,60,99}, 100},
            new object[] { new List<int> { -1,3,-5,9,11}, 0}

        };
    }

    [Test]
    public void SumOfEvenNumbers_ShallThrownException_ForNullInput()
    {
        IEnumerable<int>? input = null;

        ClassicAssert.Throws<ArgumentNullException>(
            () => input!.SumOfEvenNumbers());
    }
}