namespace HangmanHero
{
    public class EndGameController : HangmanElement
    {
        private ViewsController viewsController;

        private IScoreModel scoreModel;
        private ICurrentWordModel currentWordModel;
        private IErrorsModel errorsModel;

        public EndGameController(ICurrentWordModel currentWordModel, IErrorsModel errorsModel, ViewsController viewsController)
        {
            this.viewsController = viewsController;
            this.currentWordModel = currentWordModel;
            this.errorsModel = errorsModel;

            scoreModel = new ScoreModel();
        }

        public void GameEnd()
        {
            bool won = currentWordModel.CheckGameWon();
            bool lose = !errorsModel.AreErrorsLeft();

            if (won == lose)
            {
                throw new System.Exception("Ошибка при подсчёте результата игры");
            }

            if (won)
            {
                scoreModel.Win();
            }
            else
            {
                scoreModel.Lose();
            }

            viewsController.GameEndViewRedraw(scoreModel.GetWins(), scoreModel.GetLoses(), won, currentWordModel.GetWord());

            ModelsReset();
        }

        private void ModelsReset()
        {
            currentWordModel.Reset();
            errorsModel.Reset();
        }
    }
}
