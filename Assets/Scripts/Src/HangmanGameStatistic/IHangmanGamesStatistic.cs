using Src.HangmanCoreGameplay;

namespace Src.HangmanGameStatistic
{
    public interface IHangmanGamesStatistic
    {
        void UpdateStatistic(HangmanGameFinishedState hangmanGameFinishedState);
        int GetWinsCount();
        int GetLosesCount();
    }
}