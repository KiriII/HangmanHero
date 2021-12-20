namespace Src.HangmanCoreGameplay
{
    internal class ErrorsController : ITurnsGroupChangedListener
    {
        private IGameCoreModel _gameCoreModel;

        public ErrorsController(IGameCoreModel gameCoreModel)
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