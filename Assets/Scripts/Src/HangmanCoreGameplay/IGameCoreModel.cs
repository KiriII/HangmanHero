using TMPro;

namespace Src.HangmanCoreGameplay
{
    public interface IGameCoreModel
    {
        void AddOpenedSymbolIndex(int simbolIndex);

        bool IsTurnSymbolInWord(char turn);

        bool IsSymbolIndexOpened(int symbolIndex);

        void IncrementErrorsCount();

        void SetWord(string word);

        int GetErrorsCount();

        string GetWordInGame();

        int GetWordLenght();

        int GetOpenedCharsCount();
    }
}