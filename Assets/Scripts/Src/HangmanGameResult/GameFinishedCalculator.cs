using Src.HangmanCoreGameplay;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameFinishedCalculator
    {
        private IHangmanGameCoreData _hangmanGameCoreData;
        private MaxErrorsModel _maxErrorsModel;

        public GameFinishedCalculator()
        {
            _maxErrorsModel = new MaxErrorsModel();
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