namespace Src.HangmanGameResult
{
    public interface IHangmanGamesStatistic
    {
        void StartNewGame();
        
        int GetWinsCount();

        int GetLosesCount();
    }
}