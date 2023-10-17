using System.Collections;
using System.Text;
namespace TTT
{
    public class Board
    {
        public char[,] board = new char[3, 3];
        public Board(){

        }
        /*
         *   3 
         *   2
         *   1  
         *     a b c 
         */

        public void MakeMove(Move xPlayerMove, Move yPlayerMove)
        {
            if(xPlayerMove == null || yPlayerMove == null){
                return;
            }
            if(xPlayerMove.isValid() == false || yPlayerMove.isValid() == false){
                return;
            }
            board[xPlayerMove.GetValueX(), xPlayerMove.GetValueY()] = 'x';
            board[yPlayerMove.GetValueX(), yPlayerMove.GetValueY()] = 'o';
        }

        public bool[,] GetBitTablePlayer(Player player)
        {
            bool[,] playerBidTable = new bool[3, 3];
            
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == player.GetPlayerPiece())
                    {
                        playerBidTable[x, y] = true;
                    } 

                }
            }
            return playerBidTable;
        }
    }
}