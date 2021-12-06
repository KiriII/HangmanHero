using System;

namespace Src.HangmanCoreGameplay
{
    internal class ErrorsController
    {
        private Action<char> _onUniqTurnDone;

        private GameCoreModel _gameCoreModel;

        public ErrorsController(GameCoreModel gameCoreModel, Action<char> onUniqTurnDone)
        {
            _gameCoreModel = gameCoreModel;
            _onUniqTurnDone = onUniqTurnDone;

            _onUniqTurnDone += CheckErrorDone;
        }

        private void CheckErrorDone(char symbolInTurn)
        {
            if (_gameCoreModel.IsTurnInWord(symbolInTurn))
            {
                _gameCoreModel.IncrementErrorsCount();
            }
        }
    }
}