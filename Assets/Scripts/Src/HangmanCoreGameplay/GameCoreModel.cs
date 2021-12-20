using System;
using System.Collections.Generic;

namespace Src.HangmanCoreGameplay
{
    public class GameCoreModel : IGameCoreModel, ITurnsModel
    {
        private const int SYMBOL_NOT_FOUND_KEY = -1;
        
        private string _wordInGame;
        private int _errorsCount;
        private List<int> _openedSymbolsInWord;
        private HashSet<char> _turnsDone;

        public GameCoreModel(string wordForGame)
        {
            _wordInGame = wordForGame;
            
            _errorsCount = 0;
            _openedSymbolsInWord = new List<int>();
            _turnsDone = new HashSet<char>();
        }

        public void AddTurn(char turn)
        {
            _turnsDone.Add(turn);
        }

        public void AddOpenedSymbolIndex(int symbolIndex)
        {
            _openedSymbolsInWord.Add(symbolIndex);
        }

        public bool IsTurnSymbolInWord(char turn)
        {
            return _wordInGame.IndexOf(turn) != SYMBOL_NOT_FOUND_KEY;
        }

        public bool IsSymbolIndexOpened(int symbolIndex)
        {
            return _openedSymbolsInWord.Contains(symbolIndex);
        }
        
        public bool IsSymbolInTurns(char symbolInTurn)
        {
            return _turnsDone.Contains(symbolInTurn);
        }

        public void IncrementErrorsCount()
        {
            _errorsCount++;
        }
        
        //-------setters--------

        public void SetWord(string word)
        {
            _wordInGame = word;
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

        public int GetWordLenght()
        {
            return _wordInGame.Length;
        }

        public int GetOpenedCharsCount()
        {
            return _openedSymbolsInWord.Count;
        }

        //-------debug------

        public string Print()
        {
            return $"word is {_wordInGame}\n" +
                   $"errors count = {_errorsCount}\n" +
                   $"opened symbols: {String.Join(", ", _openedSymbolsInWord)}\n" +
                   $"turns: {String.Join(", ", _turnsDone)}";
        }
    }
}