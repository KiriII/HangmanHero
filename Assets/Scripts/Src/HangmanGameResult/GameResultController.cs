using System;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameResultController
    {
        private GameFinishedCalculator _gameFinishedCalculator;
        public event Action<HangmanGameFinishedState> _gameStateChanged;

        public GameResultController(GameFinishedCalculator gameFinishedCalculator)
        {
            _gameFinishedCalculator = gameFinishedCalculator;
        }

        public void CalculateGameResultAfterWordOpened()
        {
            if (_gameFinishedCalculator.IsGameWined())
            {
                OnGameStateChanged(HangmanGameFinishedState.Victory);
            } 
        }

        public void CalculateGameResultAfterErrorDone()
        {
            if (_gameFinishedCalculator.IsGameFailed())
            {
                OnGameStateChanged(HangmanGameFinishedState.Failed);
            } 
        }

        private void OnGameStateChanged(HangmanGameFinishedState hangmanGameFinishedState)
        {
            _gameStateChanged?.Invoke(hangmanGameFinishedState);
        }
        
        public void EnableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameStateChanged += methodInListener;
        }
        
        public void DisableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameStateChanged -= methodInListener;
        }
    }
}