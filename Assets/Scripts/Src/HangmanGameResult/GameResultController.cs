using System;

namespace Src.HangmanGameResult
{
    public class GameResultController
    {
        private GameFinishedCalculator _gameFinishedCalculator;
        public event Action<HangmanGameFinishedState> _gameStateChanged;

        public GameResultController(GameFinishedCalculator gameFinishedCalculator, Action<HangmanGameFinishedState> _gameStateChanged)
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
    }
}