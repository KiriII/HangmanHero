using UnityEngine;

namespace Src.HangmanCoreGameplay
{
    public class HangmanGameCore : IHangmanGameCore, IHangmanGameCoreData
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
        
        public bool IsHiddenWorldOpened()
        {
            var wordLenght = _gameCoreModel.GetWordLenght();
            var openedCharsCount = _gameCoreModel.GetOpenedCharsCount();
            
            return wordLenght == openedCharsCount;
        }

        public int GetErrorsCount()
        {
            return _gameCoreModel.GetErrorsCount();
        }

        // -------debug---------
        public void PrintModelState()
        {
            Debug.Log(_gameCoreModel.Print());
        }
    }
}