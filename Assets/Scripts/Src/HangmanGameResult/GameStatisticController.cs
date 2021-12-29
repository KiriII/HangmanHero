using System;
using Src.HangmanCoreGameplay;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameStatisticController
    {
        private IHangmanGameCoreData _hangmanGameCoreData;
        private IGameResultModel _gameResultModel;
        public event Action<HangmanGameFinishedState> _gameStateChanged;

        public GameStatisticController(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameResultModel = new GameResultModel();
            SetHangmanGameCoreData(hangmanGameCoreData);
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
        
        public void SetGameStateChanged(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameStateChanged += methodInListener;
        }

        public void SetHangmanGameCoreData(IHangmanGameCoreData hangmanGameCoreData)
        {
            _hangmanGameCoreData = hangmanGameCoreData;
        }
    }
}