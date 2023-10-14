using NUnit.Framework.Internal;
using TTT;

[TestFixture]
public class TestsBoard
{
    [Test]
    public void GetBitTablePlayer_PlayerHasNoPiece_ReturnsNull()
    {
        // Arrange
        Board board = new Board();
        Player player = new Player("x");

        // Act
        bool[,] result = board.GetBitTablePlayer(player);

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void GetBitTablePlayer_PlayerHasPiece_ReturnsCorrectTable()
    {
        // Arrange
        Board board = new Board();
        Player player = new Player("X");
        board.MakeMove(new Move(0, 0), new Move(0, 1));

        // Act
        bool[,] result = board.GetBitTablePlayer(player);
        bool[,] expected = new bool[3,3];
        expected[0, 0] = true;
        // Assert
        Assert.NotNull(result);
        Assert.That(expected, Is.EqualTo(result));
    }
}