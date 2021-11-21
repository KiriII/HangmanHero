namespace HangmanHero
{
    public class ErrorsModel
    {

        private int currentErrors;
        private int maxErrors;

        public ErrorsModel()
        {
            this.maxErrors = Constants.maxErrors;
            currentErrors = 0;
        }

        public int ErrorDone()
        {
            return ++currentErrors;
        }

        public bool AreErrorsLeft()
        {
            if (maxErrors - currentErrors == -1)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            currentErrors = 0;
        }
    }
}
