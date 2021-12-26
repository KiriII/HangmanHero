using System;

namespace Src.HangmanCoreGameplay
{
    public interface IHangmanGameCoreData
    {
        bool IsHiddenWordOpened();

        int GetErrorsCount();

        Action GetOpenedSymbolsGroupChanged();

        Action GetErrorsCountChanged();
    }
}