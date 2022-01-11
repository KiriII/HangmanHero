namespace Src.HangmanGameResult
{
    public class MaxErrorsModel
    {
        private const int MAX_ERRORS_COUNT = 6;

        public bool IsErrorsRunOut(int currentErrorsCount)
        {
            return MAX_ERRORS_COUNT < currentErrorsCount;
        }
    }
}