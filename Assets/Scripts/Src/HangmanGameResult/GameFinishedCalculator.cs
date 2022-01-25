using Src.HangmanCoreGameplay;
using Src.HangmanGame;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameFinishedCalculator
    {
        private IHangmanGameCoreData _hangmanGameCoreData;
        private GameRule _maxErrorsModel;

        public GameFinishedCalculator(GameRule gameRule)
        {
            _maxErrorsModel = gameRule;
        }

        public void SetHangmanGameCoreData(IHangmanGameCoreData hangmanGameCoreData)
        {
            _hangmanGameCoreData = hangmanGameCoreData;
        }

        public bool IsGameWined()
        {
            var isAllWordOpened = _hangmanGameCoreData.IsHiddenWordOpened();
            return isAllWordOpened;
        }

        public bool IsGameFailed()
        {
            var currentErrorsCount = _hangmanGameCoreData.GetErrorsCount();
            var errorsRunOut = _maxErrorsModel.IsErrorsRunOut(currentErrorsCount);
            return errorsRunOut;
        }
    }
}