using System;

namespace Src.HangmanCoreGameplay
{
    internal class TurnsController
    {
        private GameCoreModel _gameCoreModel;
        private TurnsGroupChangedHolder _turnsGroupChangedHolder;

        public TurnsController(GameCoreModel gameCoreModel, TurnsGroupChangedHolder turnsGroupChangedHolder)
        {
            _gameCoreModel = gameCoreModel;

            _turnsGroupChangedHolder = turnsGroupChangedHolder;
        }

        public void TurnResultCalculation(char symbolInTurn)
        {
            if (_gameCoreModel.IsSymbolInTurns(symbolInTurn)) return;
            AddTurn(symbolInTurn);

            _turnsGroupChangedHolder.OnTurnGroupChanged(symbolInTurn);
        }

        private void AddTurn(char turn)
        {
            _gameCoreModel.AddTurn(turn);
        }
    }
}