using System.Collections.Generic;

namespace Src.HangmanGameResult
{
    public interface IGamesStatisticModel
    {
        void AddGameToStatisticWithState(HangmanGameState gameState);

        void FinishLastInGroupGame(HangmanGameState gameState);

        int GetGamesCountWithState(HangmanGameState gameState);
        
        List<HangmanGameState> GetGamesStatistic();
    }
}