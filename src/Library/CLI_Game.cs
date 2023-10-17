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
                        Console.WriteLine("Welcom to TTT Synchronus\n bot players take turns and them they are played a the same time.");
                        Console.WriteLine("to take your turn write x or o and the row and column: x a1");
                        gameState = EnumStates.TakingTurns;
                        break;
                    case EnumStates.TakingTurns:
                        this.TakeMoves();
                        gameState = EnumStates.Move;
                        break;
                    case EnumStates.Move:
                        this.MakeMoves();
                        if (this.GameOver() != "playing")
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
        // Takes a char and int and returns the x and y value as a int[x,y]
        // TODO: create test
        override public void TakeMoves()
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