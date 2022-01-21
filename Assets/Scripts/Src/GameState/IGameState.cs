namespace Src.GameState
{
    public interface IGameState
    {
        void StartGame();
        void EndGame(HangmanGameState gameState);
    }
}