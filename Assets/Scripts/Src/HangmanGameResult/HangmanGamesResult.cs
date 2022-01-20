using System;
using Src.HangmanCoreGameplay;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class HangmanGamesResult : IHangmanGameResult
    {
        private GameResultController _gameResultController;
        private GameFinishedCalculator _gameFinishedCalculator;

        public HangmanGamesResult()
        {
            _gameFinishedCalculator = new GameFinishedCalculator();
            _gameResultController = new GameResultController(_gameFinishedCalculator);
        }
        
        public void StartNewGame(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameFinishedCalculator.SetHangmanGameCoreData(hangmanGameCoreData);
            AddActionsListeners(hangmanGameCoreData);
        }
        
        private void AddActionsListeners(IHangmanGameCoreData hangmanGameCoreData)
        {
            hangmanGameCoreData.EnableOpenedSymbolsGroupChangedListener(_gameResultController.CalculateGameResultAfterWordOpened);
            hangmanGameCoreData.EnableErrorsCountChangedListener(_gameResultController.CalculateGameResultAfterErrorDone);
        }

        public void EnableGameStateChangedListener(Action<HangmanGameState> methodInListener)
        {
            _gameResultController.EnableGameStateChangedListener(methodInListener);
        }
        
        public void DisableGameStateChangedListener(Action<HangmanGameState> methodInListener)
        {
            _gameResultController.DisableGameStateChangedListener(methodInListener);
        }
    }
}