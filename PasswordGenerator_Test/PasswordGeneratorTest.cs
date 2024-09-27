using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using PasswordGenerator;

namespace PasswordGenerator_Test;

[TestFixture]
public class PasswordGeneratorTest
{
    private PasswordGeneratorApp _cut;
    private Mock<IRandomNumber> _randomNumberMock;

    [SetUp]
    public void Setup()
    {
        _randomNumberMock = new Mock<IRandomNumber>();
        _cut = new PasswordGeneratorApp(_randomNumberMock.Object);
    }


    [Test]
    public void Generate_ShouldThrowAnArgumentOutOfRangeException_NumberLessMinNumber()
    {
        var useSpecialCharacters = true;
        ClassicAssert.Throws<ArgumentOutOfRangeException>(
            () => _cut.Generate(-1, 10, useSpecialCharacters), "rangeMin must be greater than 0");
    }

    [Test]
    public void Generate_ShouldThrowAnArgumentOutOfRangeException_MinNumberLargerThanMaxNumber()
    {
        var useSpecialCharacters = true;
        ClassicAssert.Throws<ArgumentOutOfRangeException>(
            () => _cut.Generate(10, 5, useSpecialCharacters), "rangeMin must be smaller than rangeMax");
    }

    [Test]
    public void Generate_ShouldReturnString_EEEEEE_WhenLengthIs_6_AndCharIndex_4()
    {
        _randomNumberMock
            .Setup(mock => mock.Random(It.IsAny<int>(),It.IsAny<int>()))
            .Returns(6);

        _randomNumberMock
            .Setup(mock => mock.Random(It.IsAny<int>()))
            .Returns(4);

        var expected = "EEEEEE";
        var useSpecialCharacters = false;

        var result = _cut.Generate(2,10, useSpecialCharacters);

        _randomNumberMock
            .Verify(mock => mock.Random(It.IsAny<int>()), Times.Exactly(6));

        ClassicAssert.AreEqual(expected, result);
    }
}
