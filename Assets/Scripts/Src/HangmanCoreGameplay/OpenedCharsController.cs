using System;

namespace Src.HangmanCoreGameplay
{
    internal class OpenedCharsController : ITurnsGroupChangedListener
    {
        private IGameCoreModel _gameCoreModel;

        public OpenedCharsController(IGameCoreModel gameCoreModel)
        {
            _gameCoreModel = gameCoreModel;
        }

        public void UpdateValuesAfterTurn(char symbolInTurn)
        {
            var wordInGame = _gameCoreModel.GetWordInGame();
            
            for (var i = wordInGame.IndexOf(symbolInTurn); i > -1; i = wordInGame.IndexOf(symbolInTurn, i + 1))
            {
                if (!_gameCoreModel.IsSymbolIndexOpened(i))
                {
                    _gameCoreModel.AddOpenedSymbolIndex(i);
                }
            }
        }
    }
}