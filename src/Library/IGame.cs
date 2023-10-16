namespace TTT
{
    public interface IGame
    {
        void StartGame();
        string GameOver();
        string MakeMoves();
        void TakeMoves();
    }
}