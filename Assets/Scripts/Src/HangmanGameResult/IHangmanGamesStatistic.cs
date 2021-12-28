using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public interface IHangmanGamesStatistic
    {
        void StartNewGame(IHangmanGameCoreData hangmanGameCoreData);

        int GetWinsCount();

        int GetLosesCount();
    }
}