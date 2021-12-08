using UnityEngine;

namespace Src.HangmanCoreGameplay
{
    public class HangmanGameCore
    {
        private TurnsController _turnsController;
        private ITurnsGroupChangedListener _errorsContoller;
        private ITurnsGroupChangedListener _openedCharsController;
        
        private GameCoreModel _gameCoreModel;

        public HangmanGameCore()
        {
            _gameCoreModel = new GameCoreModel();

            _errorsContoller = new ErrorsController(_gameCoreModel);
            _openedCharsController = new OpenedCharsController(_gameCoreModel);

            var turnsGroupChangedHolder =
                new TurnsGroupChangedHolder(_errorsContoller, _openedCharsController);
            _turnsController = new TurnsController(_gameCoreModel, turnsGroupChangedHolder);
        }

        public void Turn(char inputSymbol)
        {
            CheckInputSymbol(inputSymbol);
                
            _turnsController.TurnResultCalculation(inputSymbol);
        }

        public void SetWord(string word)
        {
            CheckInputWord(word);
            
            _gameCoreModel.SetWord(word);
        }

        private void CheckInputWord(string word)
        {
            if (word?.Length == 0)
            {
                throw new System.Exception("Word length equals zero");
            }
        }

        private void CheckInputSymbol(char symbol)
        {
            // TO DO
        }

        // -------debug---------
        public void PrintModelState()
        {
            Debug.Log(_gameCoreModel.Print());
        }
    }
}