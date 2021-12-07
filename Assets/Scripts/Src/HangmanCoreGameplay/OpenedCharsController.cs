using System;

namespace Src.HangmanCoreGameplay
{
    internal class OpenedCharsController : ITurnsGroupChangedListener
    {
        private GameCoreModel _gameCoreModel;

        public OpenedCharsController(GameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;
        }

        public void UpdateValuesAfterTurn(char symbolInTurn)
        {
            var wordInGame = _gameCoreModel.GetWordInGame();
            
            for (int i = wordInGame.IndexOf(symbolInTurn); i > -1; i = wordInGame.IndexOf(symbolInTurn, i + 1))
            {
                if (!_gameCoreModel.IsSymbolIndexOpened(i))
                {
                    _gameCoreModel.AddOpenedSymbolIndex(i);
                }
            }
        } 
    }
}