using System;

namespace Src.HangmanCoreGameplay
{
    internal class ErrorsController : ITurnsGroupChangedListener
    {
        private GameCoreModel _gameCoreModel;

        public ErrorsController(GameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;
        }

        public void UpdateValuesAfterTurn(char symbolInTurn)
        {
            if (!_gameCoreModel.IsTurnInWord(symbolInTurn))
            {
                _gameCoreModel.IncrementErrorsCount();
            }
        }
    }
}