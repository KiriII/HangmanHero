namespace Src.HangmanGameStatistic
{
    public interface IHangmanGamesStatistic
    {
        int GetWinsCount();
        int GetLosesCount();
        void UpdateStatistic(HangmanGameFinishedState hangmanGameFinishedState);
    }
}