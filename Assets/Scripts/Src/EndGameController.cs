using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class EndGameController : HangmanElement
    {

        private ScoreModel scoreModel;
        private CurrentWordModel currentWordModel;
        private ErrorsModel errorsModel;

        public EndGameController(CurrentWordModel currentWordModel, ErrorsModel errorsModel)
        {
            this.currentWordModel = currentWordModel;
            this.errorsModel = errorsModel;

            scoreModel = new ScoreModel();
        }

        public void GameEnd()
        {

            if (currentWordModel.CheckGameWon())
            {
                scoreModel.Win();
                app.won = true;
                ModelsReset();
            }
            else if (!errorsModel.AreErrorsLeft())
            {
                scoreModel.Lose();
                app.won = false;
                ModelsReset();
            }

            Debug.Log($"wins = {scoreModel.GetWins()} loses = {scoreModel.GetLoses()}");

        }

        private void ModelsReset()
        {
            currentWordModel.Reset();
            errorsModel.Reset();
        }
    }
}
