using System;

namespace Src.HangmanCoreGameplay
{
    public interface IHangmanGameCoreData
    {
        bool IsHiddenWordOpened();

        bool IsErrorsRunOut();

        void SetOpenedSymbolsGroupChanged(Action methodInListener);

        void SetErrorsCountChanged(Action methodInListener);
    }
}