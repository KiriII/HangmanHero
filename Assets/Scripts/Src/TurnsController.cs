using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class TurnsController 
    {
        private EndGameController endGameController;

        private CurrentWordModel currentWordModel;
        private ErrorsModel errorsModel;

        private GameStatesView gameStatesView;

        public TurnsController(CurrentWordModel currentWordModel)
        {
            this.currentWordModel = currentWordModel;
            errorsModel = new ErrorsModel();

            endGameController = new EndGameController(this.currentWordModel, errorsModel);
        }

        public void Turn(char letter)
        {
            var openedWord = currentWordModel.CheckLetterInWord(letter);

            if (openedWord)
            {
                gameStatesView.UpdateWord(currentWordModel.GetOpenChars(), currentWordModel.GetWord());
            }
            else
            {
                var errors = errorsModel.ErrorDone();

                gameStatesView.UpdateHangman(errors - 1);
            }

            if (currentWordModel.CheckGameWon() == errorsModel.AreErrorsLeft())
            {
                endGameController.GameEnd();
            }
        }

        // КОСТЫЛЬ 
        public void SetGameStateView(GameStatesView gameStatesView)
        {
            this.gameStatesView = gameStatesView;
        }
    }
}
