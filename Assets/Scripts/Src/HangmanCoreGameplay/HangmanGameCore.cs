namespace Src.HangmanCoreGameplay
{
    public class HangmanGameCore
    {
        private TurnsController _turnsController;
        private ErrorsController _errorsContoller;
        private OpenedCharsController _openedCharsController;
        
        private GameCoreModel _gameCoreModel;

        public HangmanGameCore()
        {
            _gameCoreModel = new GameCoreModel();
            
            _turnsController = new TurnsController(_gameCoreModel);
            var onUniqTurnDone = _turnsController.GetAction();
            _errorsContoller = new ErrorsController(_gameCoreModel, onUniqTurnDone);
            _openedCharsController = new OpenedCharsController(_gameCoreModel, onUniqTurnDone);
        }

        public void Turn(char inputSymbol)
        {
            _turnsController.TurnResultCalculation(inputSymbol);
        }
    }
}