using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class GameFinishedCalculator
    {
        private IHangmanGameCoreData _hangmanGameCoreData;
        private MaxErrorsModel _maxErrorsModel;

        public GameFinishedCalculator(IHangmanGameCoreData hangmanGameCoreData)
        {
            _maxErrorsModel = new MaxErrorsModel();
            SetHangmanGameCoreData(hangmanGameCoreData);
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