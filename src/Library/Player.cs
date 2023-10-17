namespace TTT
{
    public class Player
    {
        // 1 white 0 black
        EnumPlayer color;
        Move? nextMove;
        public Player(string player)
        {
            if(player.ToLower() == "x"){
                color = EnumPlayer.xPlayer; 
            }
            if(player.ToLower() == "o")
            {
                color = EnumPlayer.oPlayer;
            }
        }

        public Move GetNextMove(){
            if(nextMove == null){
                
            }
            return nextMove;
        }
        public void SetNextMove(string nextMove){
            this.nextMove = StringToMove(nextMove.ToLower());
        }
        public bool HasMove(){
            if(nextMove == null){
                return false;
            }
            return nextMove.isValid();
        }

        public char GetPlayerPiece(){
            if(color == EnumPlayer.xPlayer){
                return 'x';
            }
            if(color == EnumPlayer.oPlayer){
                return 'o';
            }
            return ' ';
        }
        private Move StringToMove(string turn)
        {
            if (turn.Length != 4)
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
            return newMove;
        }

        // gets a Char and makes it to a letter [a, b, c] -> [1, 2, 3]
        private int LetterToInt(char letter)
        {
            return char.ToUpper(letter) - 64; //index == 1
        }
    }
}