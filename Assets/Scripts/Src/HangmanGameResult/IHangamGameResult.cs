using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public interface IHangamGameResult
    {
        void StartNewGame(IHangmanGameCoreData hangmanGameCoreData);

        void SetGameStateChanged(Action<HangmanGameFinishedState> methodInListener);
    }
}