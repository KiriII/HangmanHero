namespace HangmanHero
{
    public class ErrorsModel : IErrorsModel
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
            if (currentErrors > maxErrors + 1)
            {
                throw new System.Exception("Ошибка при подсчёте ошибок. Слишком много ошибок");
            }

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
