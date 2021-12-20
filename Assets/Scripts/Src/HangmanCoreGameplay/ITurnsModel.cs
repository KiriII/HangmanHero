using System.Collections.Generic;

namespace Src.HangmanCoreGameplay
{
    public interface ITurnsModel
    {
        void AddTurn(char turn);

        bool IsSymbolInTurns(char symbolInTurn);

        HashSet<char> GetTurnsDone();
    }
}