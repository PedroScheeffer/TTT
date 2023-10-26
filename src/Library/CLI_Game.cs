namespace TTT
{
    public class CLI_Game : BaseGame
    {
override public void StartGame()
{
    Console.WriteLine("Welcome to Tic Tac Toe!");

    EnumStates gameState = EnumStates.Start;

    while (gameState != EnumStates.End)
    {
        switch (gameState)
        {
            case EnumStates.Start:
                Console.WriteLine("Welcome to TTT Synchronous");
                Console.WriteLine("Bot players take turns and then they are played at the same time.");
                Console.WriteLine("To take your turn, write x or o and the row and column: x a1");
                gameState = EnumStates.TakingTurns;
                break;

            case EnumStates.TakingTurns:
                printBoard();
                this.TakeMoves();
                gameState = EnumStates.Move;
                break;

            case EnumStates.Move:
                this.MakeMoves();

                if (this.GameOver() != "playing")
                {
                    gameState = EnumStates.End;
                }
                else
                {
                    gameState = EnumStates.TakingTurns;
                }
                break;

            default:
                gameState = EnumStates.End;
                break;
        }
    }
}
        // Takes a char and int and returns the x and y value as a int[x,y]
        // TODO: create test
        override public void TakeMoves()
        {
            string newMove;
            Console.WriteLine("Enter your turn (player and move)");
            while (true)
            {
                newMove = Console.ReadLine()?.ToLower();
                if (newMove != null)
                {
                    if (newMove.Contains('x'))
                    {
                        xPlayer.SetNextMove(newMove);
                    }
                    else if (newMove.Contains('o'))
                    {
                        oPlayer.SetNextMove(newMove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please enter a move for player 'x' or 'o'.");
                        continue;  // Vuelve al inicio del bucle
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move");
                }
                if (xPlayer.HasMove() && oPlayer.HasMove())
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Waiting for the other player's move...");
                }
            }
        }

        public void printBoard()
        {
            for (int x = 0; x < board.gameGrid.GetLength(0); x++)
            {
                Console.Write((3 - x) + " ");
                for (int y = 0; y < board.gameGrid.GetLength(1); y++)
                {
                    Console.Write(board.gameGrid[x, y] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c");
        }
    }
}