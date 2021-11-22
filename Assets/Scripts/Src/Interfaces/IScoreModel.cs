namespace HangmanHero
{
    public interface IScoreModel
    {
        void Win();

        void Lose();

        int GetWins();

        int GetLoses();
    }
}
