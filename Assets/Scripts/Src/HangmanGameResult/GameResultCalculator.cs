using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class GameResultCalculator
    {
        private IHangmanGameCoreData _hangmanGameCoreData;
        private GameResultModel _gameResultModel;

        public GameResultCalculator(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameResultModel = new GameResultModel();
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
            var errorsRunOut = _gameResultModel.IsErrorsRunOut(currentErrorsCount);
            return errorsRunOut;
        }
    }
}
