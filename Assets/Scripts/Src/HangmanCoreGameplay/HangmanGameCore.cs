using UnityEngine;

namespace Src.HangmanCoreGameplay
{
    public class HangmanGameCore
    {
        private TurnsController _turnsController;
        private ITurnsGroupChangedListener _errorsContoller;
        private ITurnsGroupChangedListener _openedCharsController;
        
        private GameCoreModel _gameCoreModel;

        private TurnsGroupChangedHolder _turnsGroupChangedHolder;

        public HangmanGameCore(string wordForGame)
        {
            _gameCoreModel = new GameCoreModel(wordForGame);

            InitInternalVariables();
        }
        
        public HangmanGameCore(GameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;

            InitInternalVariables();
        }

        private void InitInternalVariables()
        {
            _errorsContoller = new ErrorsController(_gameCoreModel);
            _openedCharsController = new OpenedCharsController(_gameCoreModel);

            _turnsGroupChangedHolder = new TurnsGroupChangedHolder(_errorsContoller, _openedCharsController);
            _turnsController = new TurnsController(_gameCoreModel, _turnsGroupChangedHolder.GetTurnGroupChanged());
        }
        
        public void Turn(char inputSymbol)
        {
            _turnsController.TurnResultCalculation(inputSymbol);
        }

        // -------debug---------
        public void PrintModelState()
        {
            Debug.Log(_gameCoreModel.Print());
        }
    }
}