using System;
using UnityEngine;

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
            if (!_gameCoreModel.IsTurnSymbolInWord(turnSymbol))
            {
                _gameCoreModel.IncrementErrorsCount();
                OnErrorsCountChanged();
            }
        }
        
        private void OnErrorsCountChanged()
        {
            _errorsCountChanged?.Invoke();
        }

        public Action GetErrorsCountChanged()
        {
            return _errorsCountChanged;
        }
    }
}