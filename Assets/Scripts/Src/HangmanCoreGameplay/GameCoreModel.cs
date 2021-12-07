using System.Collections.Generic;

namespace Src.HangmanCoreGameplay
{
    internal class GameCoreModel
    {
        private const int SYMBOL_NOT_FOUND_KEY = -1;
        
        private string _wordInGame;
        private int _errorsCount;
        private List<int> _openedSymbolsInWord;
        private HashSet<char> _turnsDone;

        public GameCoreModel()
        {
            _errorsCount = 0;
            _openedSymbolsInWord = new List<int>();
            _turnsDone = new HashSet<char>();
        }

        public void AddTurn(char turn)
        {
            _turnsDone.Add(turn);
        }

        public void AddOpenedSymbolIndex(int simbolIndex)
        {
            _openedSymbolsInWord.Add(simbolIndex);
        }

        public bool IsTurnSymbolInWord(char turn)
        {
            return _wordInGame.IndexOf(turn) == SYMBOL_NOT_FOUND_KEY;
        }

        public bool IsSymbolIndexOpened(int symbolIndex)
        {
            return _openedSymbolsInWord.Contains(symbolIndex);
        }

        public void IncrementErrorsCount()
        {
            _errorsCount++;
        }
        
        //-------getters--------
        public HashSet<char> GetTurnsDone()
        {
            return _turnsDone;
        }

        public int GetErrorsCount()
        {
            return _errorsCount;
        }
        public string GetWordInGame()
        {
            return _wordInGame;
        }
    }
}