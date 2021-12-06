using System;

namespace Src.HangmanCoreGameplay
{
    internal class OpenedCharsController
    {
        private Action<char> _onUniqTurnDone;
        
        private GameCoreModel _gameCoreModel;

        public OpenedCharsController(GameCoreModel gameCoreModel, Action<char> onUniqTurnDone)
        {
            _gameCoreModel = gameCoreModel;
            
            _onUniqTurnDone = onUniqTurnDone;

            _onUniqTurnDone += CheckCharOpened;
        }

        private void CheckCharOpened(char symbolInTurn)
        {
            var wordInGame = _gameCoreModel.GetWordInGame();
            
            for (int i = wordInGame.IndexOf(symbolInTurn); i > -1; i = wordInGame.IndexOf(symbolInTurn, i + 1))
            {
                if (_gameCoreModel.IsSymbolIndexOpened(i))
                {
                    _gameCoreModel.AddOpenedSymbolIndex(i);
                }
            }
        } 
    }
}