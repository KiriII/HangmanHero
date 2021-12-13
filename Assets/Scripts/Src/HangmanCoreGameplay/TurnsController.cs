using System;

namespace Src.HangmanCoreGameplay
{
    internal class TurnsController
    {
        private GameCoreModel _gameCoreModel;
        private Action<char> _turnsGroupChanged;

        public TurnsController(GameCoreModel gameCoreModel, Action<char> turnsGroupChanged)
        {
            _gameCoreModel = gameCoreModel;

            _turnsGroupChanged = turnsGroupChanged;
        }

        public void TurnResultCalculation(char symbolInTurn)
        {
            if (_gameCoreModel.IsSymbolInTurns(symbolInTurn)) return;
            AddTurn(symbolInTurn);

            OnTurnGroupChanged(symbolInTurn);
        }

        private void AddTurn(char turn)
        {
            _gameCoreModel.AddTurn(turn);
        }
        
        private void OnTurnGroupChanged(char symbol)
        {
            _turnsGroupChanged?.Invoke(symbol);
        }
    }
}