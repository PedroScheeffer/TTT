
namespace TTT
{
    public class Game
    {
        private Board board;
        private Player xPlayer;
        private Player oPlayer;
        private static Game instance;
        public static Game Instance
        {
            get
            {
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }

        public Game()
        {
            Board _board = new Board();
            oPlayer = new Player("o");
            xPlayer = new Player("x");

            StartGame();
        }

        public static void StartGame()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            EnumStates gameState = EnumStates.Start;
            while (gameState != EnumStates.End)
            {
                switch (gameState)
                {
                    case EnumStates.Start:
                        Console.WriteLine("Welcom to TTT Synchronus\n bot players take turns and them they are played a the same time.");
                        Console.WriteLine("to take your turn write x or o and the row and column: x a1");
                        gameState = EnumStates.TakingTurns;
                        break;
                    case EnumStates.TakingTurns:
                        Instance.TakeMoves();
                        gameState = EnumStates.Move;
                        break;
                    case EnumStates.Move:
                        Instance.MakeMoves();
                        if (Instance.GameOver() != "playing")
                        {
                            gameState = EnumStates.End;
                            break;
                        }
                        gameState = EnumStates.TakingTurns;
                        break;
                    default:
                        gameState = EnumStates.End;
                        break;
                }
            }
        }
        
        // TODO: check the board and if return the stat, playing, player won or drawn
        // Pseudo toma el array board lo separa en dos bitmaps uno para cada jugador, revisa si hay alguno con 3 en linea
        // si lo hay, devuelve el ganador o drawn si los dos jugadores consiguieron al mismo tiempo
        // si no existe pasa takingTurns
        public  string GameOver()
        {
            bool[,] oPlayerPices = board.GetBitTablePlayer(oPlayer);
            bool[,] xPlayerPices = board.GetBitTablePlayer(xPlayer);

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
            Instance.board.MakeMove(xPlayer.GetNextMove(), oPlayer.GetNextMove());
            return "move made";
        }

        // Takes a char and int and returns the x and y value as a int[x,y]
        // TODO: create test
        public void TakeMoves()
        {
            String newMove = "";
            Console.WriteLine("Enter your turn (player and move)");
            while (!xPlayer.HasMove() && !oPlayer.HasMove())
            {
                newMove = Console.ReadLine().ToLower();
                if (newMove.Contains('x'))
                {
                    xPlayer.SetNextMove(newMove);
                }
                else
                {
                    if (newMove.Contains("o"))
                    {
                        oPlayer.SetNextMove(newMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move");
                    }
                }

            }

        }
    }

}