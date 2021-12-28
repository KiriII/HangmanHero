using System;
using UnityEngine;
using Object = System.Object;

namespace Src.HangmanCoreGameplay
{
    internal class ErrorsController : ITurnsGroupChangedListener
    {
        private IGameCoreModel _gameCoreModel;
        public event Action _errorsCountChanged;

        public ErrorsController(IGameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;
        }

        public void UpdateValuesAfterTurn(char turnSymbol)
        {
            if (_gameCoreModel.IsTurnSymbolInWord(turnSymbol)) return;
            _gameCoreModel.IncrementErrorsCount();
            OnErrorsCountChanged();
        }
        
        private void OnErrorsCountChanged()
        {
            _errorsCountChanged?.Invoke();
        }

        public void SetErrorsCountChanged(Action methodInListener)
        {
            _errorsCountChanged += methodInListener;
        }
    }
}