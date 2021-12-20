using System;

namespace Src.HangmanCoreGameplay
{
    internal class TurnsController
    {
        private ITurnsModel _turnsModel;
        private Action<char> _turnsGroupChanged;

        public TurnsController(ITurnsModel turnsModel, Action<char> turnsGroupChanged)
        {
            _turnsModel = turnsModel;

            _turnsGroupChanged = turnsGroupChanged;
        }

        public void TurnResultCalculation(char symbolInTurn)
        {
            if (_turnsModel.IsSymbolInTurns(symbolInTurn)) return;
            AddTurn(symbolInTurn);

            OnTurnGroupChanged(symbolInTurn);
        }

        private void AddTurn(char turn)
        {
            _turnsModel.AddTurn(turn);
        }
        
        private void OnTurnGroupChanged(char symbol)
        {
            _turnsGroupChanged?.Invoke(symbol);
        }
    }
}