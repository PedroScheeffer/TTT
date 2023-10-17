
namespace TTT
{
    public abstract class BaseGame : IGame
    {
        public Board board{
            get;
            private set;
        }
        public Player xPlayer{
            get;
            private set;
        }
        public Player oPlayer{
            get;
            private set;
        }

        public BaseGame()
        {
            board = new Board();
            oPlayer = new Player("o");
            xPlayer = new Player("x");

            StartGame();
        }

        public abstract void StartGame();

        // TODO: check the board and if return the stat, playing, player won or drawn
        // Pseudo toma el array board lo separa en dos bitmaps uno para cada jugador, revisa si hay alguno con 3 en linea
        // si lo hay, devuelve el ganador o drawn si los dos jugadores consiguieron al mismo tiempo
        // si no existe pasa takingTurns
        public string GameOver()
        {
            bool[,] oPlayerPices = board.GetBitTablePlayer(oPlayer);
            bool[,] xPlayerPices = board.GetBitTablePlayer(xPlayer);
            return "";
        }

        // Check the moves and if viable make them, otherwise move to next turn. 
        // TODO: create Tests
        public string MakeMoves()
        {
            if(!xPlayer.HasMove() && !oPlayer.HasMove())
            { 
                return "no moves";
            }
            bool xValueSame = xPlayer.GetNextMove().GetValueX() == oPlayer.GetNextMove().GetValueX();
            bool yValueSame = xPlayer.GetNextMove().GetValueY() == oPlayer.GetNextMove().GetValueY();
            if(xValueSame == yValueSame){
                return "move colide";
            }
            this.board.MakeMove(xPlayer.GetNextMove(), oPlayer.GetNextMove());
            return "move made";
        }

        public abstract void TakeMoves();
    }

}