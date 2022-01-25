namespace Src.HangmanGame
{
    public class GameRule
    {
        private const int MAX_ERRORS_COUNT = 6;

        public bool IsErrorsRunOut(int currentErrorsCount)
        {
            return MAX_ERRORS_COUNT < currentErrorsCount;
        }
    }
}