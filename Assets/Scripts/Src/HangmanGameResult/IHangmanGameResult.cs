using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public interface IHangmanGameResult
    {
        void StartNewGame(IHangmanGameCoreData hangmanGameCoreData);

        void EnableGameStateChangedListener(Action<HangmanGameState> methodInListener);
        
        void DisableGameStateChangedListener(Action<HangmanGameState> methodInListener);
    }
}