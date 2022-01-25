using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public interface IHangmanGameResult
    {
        void EnableGameStateChangedListener(Action<HangmanGameState> methodInListener);
        
        void DisableGameStateChangedListener(Action<HangmanGameState> methodInListener);
    }
}