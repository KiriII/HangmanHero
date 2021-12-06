using System.Collections.Generic;

namespace Src.HangmanCoreGameplay
{
    public interface ITurnsGroupChangeManager
    {
        void AddTurnsListener(ITurnsGroupChangeListener turnsGroupObserver);
        void RemoveTurnsListener(ITurnsGroupChangeListener turnsGroupObserver);
        void NotifyTurnsListener();
    }
}