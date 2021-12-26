using System;
using Src.HangmanCoreGameplay;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class HangmanGamesStatistic : IHangmanGamesStatistic
    {
        private IGamesStatisticModel _gamesStatisticModel;
        private GameStatisticController _gameStatisticController;

        public HangmanGamesStatistic(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gamesStatisticModel = new HangmanStatisticModel();
            _gameStatisticController = new GameStatisticController(_gamesStatisticModel, hangmanGameCoreData);

            AddActionsListeners(hangmanGameCoreData);
        }

        //BAD
        private void AddActionsListeners(IHangmanGameCoreData hangmanGameCoreData)
        {
            var openedSymbolsGroupChanged = hangmanGameCoreData.GetOpenedSymbolsGroupChanged();
            Debug.Log(hangmanGameCoreData.GetOpenedSymbolsGroupChanged() == null);
            openedSymbolsGroupChanged += _gameStatisticController.CalculateGameResultAfterWordOpened;
            Debug.Log(hangmanGameCoreData.GetOpenedSymbolsGroupChanged() == null);
            
            var errorsCountChanged = hangmanGameCoreData.GetErrorsCountChanged();
            errorsCountChanged += _gameStatisticController.CalculateGameResultAfterErrorDone;
        }
        
        public void StartNewGame()
        {
            _gamesStatisticModel.AddGameToStatisticWithState(HangmanGameState.GameInProgress);
        }

        public int GetWinsCount()
        {
            Debug.Log($"{String.Join(", ", _gamesStatisticModel.GetGamesStatistic())}");
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameState.Victory);
        }

        public int GetLosesCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameState.Failed);
        }
    }
}