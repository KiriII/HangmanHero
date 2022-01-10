using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class GameResultController
    {
        private IHangmanGameCoreData _hangmanGameCoreData;
        private GameResultModel _gameResultModel;
        public event Action<HangmanGameFinishedState> _gameStateChanged;

        public GameResultController(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameResultModel = new GameResultModel();
            SetHangmanGameCoreData(hangmanGameCoreData);
        }
        
        public void SetHangmanGameCoreData(IHangmanGameCoreData hangmanGameCoreData)
        {
            _hangmanGameCoreData = hangmanGameCoreData;
        }

        public void CalculateGameResultAfterWordOpened()
        {
            if (IsGameWined())
            {
                OnGameStateChanged(HangmanGameFinishedState.Victory);
            } 
        }
        
        private bool IsGameWined()
        {
            var isAllWordOpened = _hangmanGameCoreData.IsHiddenWordOpened();
            return isAllWordOpened;
        }

        public void CalculateGameResultAfterErrorDone()
        {
            if (IsGameFailed())
            {
                OnGameStateChanged(HangmanGameFinishedState.Failed);
            } 
        }

        private bool IsGameFailed()
        {
            var currentErrorsCount = _hangmanGameCoreData.GetErrorsCount();
            var errorsRunOut = _gameResultModel.IsErrorsRunOut(currentErrorsCount);
            return errorsRunOut;
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