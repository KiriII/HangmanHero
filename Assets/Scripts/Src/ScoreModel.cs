namespace HangmanHero
{
    public class ScoreModel : IScoreModel
    {

        private int wins;
        private int loses;

        public ScoreModel()
        {
            wins = 0;
            loses = 0;
        }

        public void Win()
        {
            wins++;
        }

        public void Lose()
        {
            loses++;
        }

        // getters 

        public int GetWins()
        {
            return wins;
        }

        public int GetLoses()
        {
            return loses;
        }
    }
}
