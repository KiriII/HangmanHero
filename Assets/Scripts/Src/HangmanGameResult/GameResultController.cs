using System;

namespace Src.HangmanGameResult
{
    public class GameResultController
    {
        private GameResultCalculator _gameResultCalculator;
        public event Action<HangmanGameFinishedState> _gameStateChanged;

        public GameResultController(GameResultCalculator gameResultCalculator)
        {
            _gameResultCalculator = gameResultCalculator;
        }

        public void CalculateGameResultAfterWordOpened()
        {
            if (_gameResultCalculator.IsGameWined())
            {
                OnGameStateChanged(HangmanGameFinishedState.Victory);
            } 
        }

        public void CalculateGameResultAfterErrorDone()
        {
            if (_gameResultCalculator.IsGameFailed())
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