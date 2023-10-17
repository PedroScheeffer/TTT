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
        public void Test_LetterA()
        {   
            // a b c 
            // 1 2 3 
            // Act
            player.SetNextMove("x A2");
            Move actual = player.GetNextMove();
            Move expected = new Move(1,2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_LetterB()
        {
            // Act
            player.SetNextMove("x b1");
            Move actual = player.GetNextMove();
            Move expected = new Move(2,1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_LetterC()
        {
            // Act
            player.SetNextMove("x c1");
            Move actual = player.GetNextMove();
            Move expected = new Move(3,1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}