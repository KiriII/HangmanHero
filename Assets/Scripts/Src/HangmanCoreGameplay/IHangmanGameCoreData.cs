using System;

namespace Src.HangmanCoreGameplay
{
    public interface IHangmanGameCoreData
    {
        bool IsHiddenWordOpened();

        void SetOpenedSymbolsGroupChanged(Action methodInListener);

        void SetErrorsCountChanged(Action methodInListener);

        int GetErrorsCount();
    }
}