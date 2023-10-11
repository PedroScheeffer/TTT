using NUnit.Framework.Internal;

namespace TTT
{
    public class TestGame
    {
        [Test]
        public void testCreateBoard(){
            int result = Game.NewGame().GetBoard().lenght;
            int expected = 9;

             
        } 
    }

}