namespace HangmanHero
{
    public interface IErrorsModel
    {
        int ErrorDone();

        bool AreErrorsLeft();

        void Reset();
    }
}