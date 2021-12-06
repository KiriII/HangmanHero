using System;

namespace Src.HangmanCoreGameplay
{
    internal class TurnsController
    {
        private GameCoreModel _gameCoreModel;
        private event Action<char> _onUniqTurnDone;

        public TurnsController(GameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;
        }
        public void TurnResultCalculation(char symbolInTurn)
        {
            if (CheckSymbolInTurnsGroup(symbolInTurn))
            {
                AddTurn(symbolInTurn);

                OnOnUniqTurnDone(symbolInTurn);
            }
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

        protected virtual void OnOnUniqTurnDone(char symbolInTurn)
        {
            _onUniqTurnDone?.Invoke(symbolInTurn);
        }

        public Action<char> GetAction()
        {
            return _onUniqTurnDone;
        }
    }
}