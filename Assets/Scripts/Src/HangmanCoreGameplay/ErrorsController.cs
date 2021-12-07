namespace Src.HangmanCoreGameplay
{
    internal class ErrorsController : ITurnsGroupChangedListener
    {
        private GameCoreModel _gameCoreModel;

        public ErrorsController(GameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;
        }

        public void UpdateValuesAfterTurn(char turnSymbol)
        {
            if (!_gameCoreModel.IsTurnSymbolInWord(turnSymbol))
            {
                _gameCoreModel.IncrementErrorsCount();
            }
        }
    }
}