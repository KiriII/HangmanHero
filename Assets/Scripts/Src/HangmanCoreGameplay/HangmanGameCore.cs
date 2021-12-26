using System;
using UnityEngine;

namespace Src.HangmanCoreGameplay
{
    public class HangmanGameCore : IHangmanGameCore, IHangmanGameCoreData
    {
        private TurnsController _turnsController;
        private ErrorsController _errorsContoller;
        private OpenedCharsController _openedCharsController;
        
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
        
        public bool IsHiddenWordOpened()
        {
            var wordLenght = _gameCoreModel.GetWordLenght();
            var openedCharsCount = _gameCoreModel.GetOpenedCharsCount();
            
            return wordLenght == openedCharsCount;
        }

        public int GetErrorsCount()
        {
            return _gameCoreModel.GetErrorsCount();
        }

        public Action GetOpenedSymbolsGroupChanged()
        {
            return _openedCharsController.GetOpenedSymbolsGroupChanged();
        }

        public Action GetErrorsCountChanged()
        {
            return _errorsContoller.GetErrorsCountChanged();
        }


        // -------debug---------
        public void PrintModelState()
        {
            Debug.Log(_gameCoreModel.Print());
        }
    }
}