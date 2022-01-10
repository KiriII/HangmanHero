using System;

namespace Src.HangmanCoreGameplay
{
    public interface IHangmanGameCoreData
    {
        bool IsHiddenWordOpened();

        void EnableOpenedSymbolsGroupChangedListener(Action methodInListener);
        
        void DisableOpenedSymbolsGroupChangedListener(Action methodInListener);

        void EnableErrorsCountChangedListener(Action methodInListener);
        
        void DisableErrorsCountChangedListener(Action methodInListener);

        int GetErrorsCount();
    }
}