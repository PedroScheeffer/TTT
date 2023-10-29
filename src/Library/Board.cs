using System.Collections;
using System.Text;
namespace TTT
{
    public class Board
    {
        public char[,] gameGrid = new char[3, 3];
        public Board(){

        }
        /*
         *  3 [a3] [b3] [c3]
         *  2 [a2] [b2] [c2]
         *  1 [a1] [b1] [c1]
         *     a   b    c 
         */

        public void MakeMove(Move xPlayerMove, Move yPlayerMove)
        {
            if(xPlayerMove == null || yPlayerMove == null){
                return;
            }
            if(xPlayerMove.isValid() == false || yPlayerMove.isValid() == false){
                return;
            }
            gameGrid[xPlayerMove.GetValueX(), xPlayerMove.GetValueY()] = 'x';
            gameGrid[yPlayerMove.GetValueX(), yPlayerMove.GetValueY()] = 'o';
        }

        public bool[,] GetBitTablePlayer(Player player)
        {
            bool[,] playerBidTable = new bool[3, 3];
            
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                for (int y = 0; y < gameGrid.GetLength(1); y++)
                {
                    if (gameGrid[x, y] == player.GetPlayerPiece())
                    {
                        playerBidTable[x, y] = true;
                    } 

                }
            }
            return playerBidTable;
        }

        internal void printBoard()
        {

            throw new NotImplementedException();
        }
    }
}