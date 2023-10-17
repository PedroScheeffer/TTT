using NUnit.Framework.Internal;
using TTT;
namespace TTT
{

    [TestFixture]
    public class TestsBoard
    {
        [Test]
        public void GetBitTablePlayer_PlayerHasNoPiece()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player("x");

            // Act
            bool[,] result = board.GetBitTablePlayer(player);
            bool[,] expected = new bool[3,3];
            // Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void GetBitTablePlayer_PlayerHasPiece()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player("X");
            board.MakeMove(new Move(0, 0), new Move(0, 1));

            // Act
            bool[,] result = board.GetBitTablePlayer(player);
            bool[,] expected = new bool[3, 3];
            expected[0, 0] = true;
            // Assert
            Assert.NotNull(result);
             Assert.That(expected, Is.EqualTo(result));
        }
        [Test]
        public void MakeMove_ValidMove()
        {
            // Arrange
            var board = new Board();
            var xPlayerMove = new Move(0, 0);
            var yPlayerMove = new Move(1, 1);

            // Act
            board.MakeMove(xPlayerMove, yPlayerMove);

            // Assert
            Assert.AreEqual('x', board.board[0, 0]);
            Assert.AreEqual('o', board.board[1, 1]);
        }
        [Test]
        public void MakeMove_inValidMoves()
        {
            // Arrange
            var board = new Board();
            var xPlayerMove = new Move(5, -1);
            var yPlayerMove = new Move(4, 2);

            // Act
            char[,] expected = board.board;
            board.MakeMove(xPlayerMove, yPlayerMove);
            var actual = board.board;

            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}