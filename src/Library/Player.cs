using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TTT
{
    public class Player
    {
        // 1 white 0 black
        EnumPlayer color;
        Move? nextMove;
        public Player(string player)
        {
            if (player.ToLower() == "x")
            {
                color = EnumPlayer.xPlayer;
            }
            if (player.ToLower() == "o")
            {
                color = EnumPlayer.oPlayer;
            }
        }

        public void SetNextMove(string? nextMove)
        {
            if (nextMove == "")
            {
                this.nextMove = null;
            }
            else
            {
                this.nextMove = StringToMove(nextMove.ToLower());
            }
        }
        public bool HasMove()
        {
            if (nextMove == null)
            {
                return false;
            }
            return nextMove.isValid();
        }
        public Move GetNextMove()
        {
            return nextMove;
        }

        public char GetPlayerPiece()
        {
            if (color == EnumPlayer.xPlayer)
            {
                return 'x';
            }
            if (color == EnumPlayer.oPlayer)
            {
                return 'o';
            }
            return ' ';
        }

        // Converts a string representation of a turn into a Move object.
        // the representation should be {player} {move}. 
        // where player is "x" or "o" and
        // move is a letter and a number in the range [1,2,3] and [a,b,c]
        private Move StringToMove(string turn)
        {
            if (turn.Length != 4 || !turn.Any("123abcxo".Contains))
            {
                return null;
            }
            // x a1
            String[] move = turn.Split(" ");
            int x, y;
            // x value
            x = LetterToInt(move[1][0]);
            // y value
            y = int.Parse(move[1][1].ToString()) - 1;
            Move newMove = new Move(x, y);
            Debug.WriteLine("set new move to " + newMove.ToString());
            return newMove;
        }

        // gets a Char and makes it to a letter [a, b, c] -> [1, 2, 3]
        private int LetterToInt(char letter)
        {
            return char.ToUpper(letter) - 64; //index == 1
        }
    }
}