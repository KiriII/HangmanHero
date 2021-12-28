using System.Collections.Generic;

namespace Src.HangmanGameResult
{
    public interface IGamesStatisticModel
    {
        void AddGameToStatisticWithState(HangmanGameFinishedState gameFinishedState);

        int GetGamesCountWithState(HangmanGameFinishedState gameFinishedState);
        
        List<HangmanGameFinishedState> GetGamesStatistic();
    }
}