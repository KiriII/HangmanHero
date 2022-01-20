using System;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameResultController
    {
        private GameFinishedCalculator _gameFinishedCalculator;
        public event Action<HangmanGameState> _gameStateChanged;

        public GameResultController(GameFinishedCalculator gameFinishedCalculator)
        {
            _gameFinishedCalculator = gameFinishedCalculator;
        }

        public void CalculateGameResultAfterWordOpened()
        {
            if (_gameFinishedCalculator.IsGameWined())
            {
                OnGameStateChanged(HangmanGameState.GameWon);
            } 
        }

        public void CalculateGameResultAfterErrorDone()
        {
            if (_gameFinishedCalculator.IsGameFailed())
            {
                OnGameStateChanged(HangmanGameState.GameLost);
            } 
        }

        private void OnGameStateChanged(HangmanGameState hangmanGameFinishedState)
        {
            _gameStateChanged?.Invoke(hangmanGameFinishedState);
        }
        
        public void EnableGameStateChangedListener(Action<HangmanGameState> methodInListener)
        {
            _gameStateChanged += methodInListener;
        }
        
        public void DisableGameStateChangedListener(Action<HangmanGameState> methodInListener)
        {
            _gameStateChanged -= methodInListener;
        }
    }
}