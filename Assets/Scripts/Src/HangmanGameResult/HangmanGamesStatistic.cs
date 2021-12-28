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
        
        private void AddActionsListeners(IHangmanGameCoreData hangmanGameCoreData)
        {
            hangmanGameCoreData.SetOpenedSymbolsGroupChanged(_gameStatisticController.CalculateGameResultAfterWordOpened);
            hangmanGameCoreData.SetErrorsCountChanged(_gameStatisticController.CalculateGameResultAfterErrorDone);
        }

        public void StartNewGame(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameStatisticController = new GameStatisticController(_gamesStatisticModel, hangmanGameCoreData);
            AddActionsListeners(hangmanGameCoreData);
        }

        public int GetWinsCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameFinishedState.Victory);
        }

        public int GetLosesCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameFinishedState.Failed);
        }
    }
}