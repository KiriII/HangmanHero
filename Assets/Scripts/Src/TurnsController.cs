namespace HangmanHero
{
    public class TurnsController
    {
        private EndGameController endGameController;
        private ViewsController viewsController;

        private ICurrentWordModel currentWordModel;
        private IErrorsModel errorsModel;

        public TurnsController(ICurrentWordModel currentWordModel, ViewsController viewsController)
        {
            this.currentWordModel = currentWordModel;
            this.viewsController = viewsController;
            errorsModel = new ErrorsModel();

            endGameController = new EndGameController(this.currentWordModel, errorsModel, viewsController);
        }

        public void Turn(char letter)
        {
            var openedWord = currentWordModel.CheckLetterInWord(letter);

            if (openedWord)
            {
                viewsController.WordViewUpdate(currentWordModel.GetOpenChars(), currentWordModel.GetWord());
            }
            else
            {
                var errors = errorsModel.ErrorDone();

                viewsController.HangmanViewUpdate(errors - 1);
            }

            if (currentWordModel.CheckGameWon() == errorsModel.AreErrorsLeft())
            {
                endGameController.GameEnd();
            }
        }
    }
}
