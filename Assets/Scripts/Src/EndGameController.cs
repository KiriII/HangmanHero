namespace HangmanHero
{
    public class EndGameController : HangmanElement
    {
        private ViewsController viewsController;

        private ScoreModel scoreModel;
        private CurrentWordModel currentWordModel;
        private ErrorsModel errorsModel;

        public EndGameController(CurrentWordModel currentWordModel, ErrorsModel errorsModel, ViewsController viewsController)
        {
            this.viewsController = viewsController;
            this.currentWordModel = currentWordModel;
            this.errorsModel = errorsModel;

            scoreModel = new ScoreModel();
        }

        public void GameEnd()
        {
            bool won = false; 

            if (currentWordModel.CheckGameWon())
            {
                scoreModel.Win();
                won = true;
            }
            else if (!errorsModel.AreErrorsLeft())
            {
                scoreModel.Lose();
                won = false;
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
