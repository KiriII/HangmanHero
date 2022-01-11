using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class HangmanGameResult : IHangamGameResult
    {
        private GameResultController _gameResultController;
        private GameFinishedCalculator _gameFinishedCalculator;
        
        public event Action<HangmanGameFinishedState> _gameStateChanged;

        public HangmanGameResult(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameFinishedCalculator = new GameFinishedCalculator(hangmanGameCoreData);
            _gameResultController = new GameResultController(_gameFinishedCalculator, _gameStateChanged);

            StartNewGame(hangmanGameCoreData);
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