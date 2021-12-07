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
            if (!CheckSymbolInTurnsGroup(symbolInTurn)) return;
            AddTurn(symbolInTurn);

            _turnsGroupChangedHolder.OnTurnGroupChanged(symbolInTurn);
        }

        private bool CheckSymbolInTurnsGroup(char symbolInTurn)
        {
            var turnsDone= _gameCoreModel.GetTurnsDone();

            return turnsDone.Contains(symbolInTurn);
        }

        private void AddTurn(char turn)
        {
            _gameCoreModel.AddTurn(turn);
        }
    }
}