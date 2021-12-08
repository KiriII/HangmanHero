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

            _turnsController = new TurnsController(_gameCoreModel, 
                new TurnsGroupChangedHolder(_errorsContoller, _openedCharsController));
        }

        public void Turn(char inputSymbol)
        {
            // check not special symbol or space 
            _turnsController.TurnResultCalculation(inputSymbol);
        }

        public void SetWord(string word)
        {
            if (word?.Length == 0)
            {
                throw new System.Exception("Word length equals zero");
            }
            _gameCoreModel.SetWord(word);
        }

        // -------debug---------
        public void PrintModelState()
        {
            Debug.Log(_gameCoreModel.Print());
        }
    }
}