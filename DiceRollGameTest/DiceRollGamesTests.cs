using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace DiceRollGameTest;

[TestFixture]
public class DiceRollGamesTests
{
    private GuessingGame _cut;
    private Mock<IDice> _diceMock;
    private Mock<IUserCommunication> _userComunnicationMock;

    [SetUp]
    public void Setup()
    {
        _diceMock = new Mock<IDice>();
        _userComunnicationMock = new Mock<IUserCommunication>();
        _cut = new GuessingGame(_diceMock.Object, _userComunnicationMock.Object);
    }

    [Test]
    public void Play_ShouldReturnVictoryOnFirstTry_IfUserInputEquelsDiceNumber()
    {
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(3);
        _userComunnicationMock
            .Setup(m => m.ReadInteger(It.IsAny<string>()))
            .Returns(3);
        var result = _cut.Play();
        GameResult expected = GameResult.Victory;

        _diceMock
            .Verify(mock => mock.Roll(), Times.Exactly(1));

        _userComunnicationMock
            .Verify(m => m.ReadInteger(It.IsAny<string>()), Times.Exactly(1));

        ClassicAssert.AreEqual(expected, result);
    }

    [Test]
    public void Play_ShouldReturnVictoryOnSecondTry_IfUserInputEquelsDiceNumber()
    {
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(5);
        _userComunnicationMock
            .SetupSequence(m => m.ReadInteger(It.IsAny<string>()))
            .Returns(3)
            .Returns(5);
        var result = _cut.Play();
        GameResult expected = GameResult.Victory;

        _diceMock
            .Verify(mock => mock.Roll(), Times.Exactly(1));

        _userComunnicationMock
            .Verify(m => m.ReadInteger(It.IsAny<string>()), Times.Exactly(2));

        ClassicAssert.AreEqual(expected, result);
    }

    [Test]
    public void Play_ShouldReturnVictoryOnLastTry_IfUserInputEquelsDiceNumberOnLastTry()
    {
        var dice = _diceMock
            .SetupSequence(mock => mock.Roll())
            .Returns(4);
        var user = _userComunnicationMock
            .SetupSequence(m => m.ReadInteger(It.IsAny<string>()))
            .Returns(6)
            .Returns(5)
            .Returns(4);
        var result = _cut.Play();
        GameResult expected = GameResult.Victory;

        _diceMock
            .Verify(mock => mock.Roll(), Times.Exactly(1));

        _userComunnicationMock
            .Verify(m => m.ReadInteger(It.IsAny<string>()), Times.Exactly(3));

        ClassicAssert.AreEqual(expected, result);
    }

    [Test]
    public void Play_ShouldReturnLossOnLastTry_IfUserInputNotEquelsDiceNumber()
    {
        var dice = _diceMock
            .SetupSequence(mock => mock.Roll())
            .Returns(2);
        var user = _userComunnicationMock
            .SetupSequence(m => m.ReadInteger(It.IsAny<string>()))
            .Returns(6)
            .Returns(5)
            .Returns(4);
        var result = _cut.Play();
        GameResult expected = GameResult.Loss;

        _diceMock
            .Verify(mock => mock.Roll(), Times.Exactly(1));

        _userComunnicationMock
            .Verify(m => m.ReadInteger(It.IsAny<string>()), Times.Exactly(3));

        ClassicAssert.AreEqual(expected, result);
    }

    [TestCase(GameResult.Victory, "You win!")]
    [TestCase(GameResult.Loss, "You lose :(")]
    public void PrintResult_ShallShowProperMessageForGameResult(
        GameResult gameResult, string expectedMessage)
    {
        _cut.PrintResult(gameResult);
        _userComunnicationMock.Verify(mock => mock.ShowMessage(expectedMessage));
    }

}
