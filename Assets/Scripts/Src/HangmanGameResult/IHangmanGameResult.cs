using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public interface IHangmanGameResult
    {
        void StartNewGame(IHangmanGameCoreData hangmanGameCoreData);

        void EnableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener);
        
        void DisableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener);
    }
}