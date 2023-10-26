using NUnit.Framework.Internal;
namespace TTT
{
    [TestFixture]
    public class TestsPlayer
    {
        private Player player;

        [SetUp]
        public void Setup()
        {
            player = new Player("x");
        }

        [Test]
        public void Test_PlayerCreation()
        {
            // Act
            Player playerx = new Player("x");
            Player playerX = new Player("X");
            Player playero = new Player("o");

            var expectedo = 'o';
            var expectedx = 'x';
            // Assert
            Assert.That(expectedo, Is.EqualTo(playero.GetPlayerPiece()));
            Assert.That(expectedx, Is.EqualTo(playerX.GetPlayerPiece()));
            Assert.That(expectedx, Is.EqualTo(playerx.GetPlayerPiece()));
        }

        [Test]
        public void Test_HasMoveNormalMove()
        {
            // Act
            player.SetNextMove("x a1");
            bool actual = player.HasMove();

            // Assert   
            Assert.IsTrue(actual);
        }
        [Test]
        public void Test_nullMove()
        {
            // Act
            player = new Player("o");
            bool actual = player.HasMove();

            // Assert   
            Assert.IsFalse(actual);
        }

        [Test]
        public void SetNextMove_WhenCalledWithValidInput()
        {
            // Arrange
            player = new Player("x");

            // Act
            player.SetNextMove("x a1");

            // Assert
            Assert.IsTrue(player.GetNextMove().isValid());
        }

        [Test]
        public void SetNextMove_WhenCalledWithInvalidInput()
        {
            // Arrange
            player = new Player("x");

            // Act
            player.SetNextMove("e t8");
            var actual = player.GetNextMove();
            Move expected = null;

            // Assert
            Assert.IsTrue(actual == expected);
        }
        [Test]
        public void Test_LetterA()
        {
            // a b c 
            // 1 2 3 
            // Act
            player.SetNextMove("x A2");
            int actual = player.GetNextMove().GetValueX();
            int expected = new Move(1, 2).GetValueX();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_LetterB()
        {
            // Act
            player.SetNextMove("x b1");
            int actual = player.GetNextMove().GetValueX();
            int expected = new Move(2, 1).GetValueX();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_LetterC()
        {
            // Act
            player.SetNextMove("x c1");
            int actual = player.GetNextMove().GetValueX();
            int expected = new Move(3, 1).GetValueX();

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}