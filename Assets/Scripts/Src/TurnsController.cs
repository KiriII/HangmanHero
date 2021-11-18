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

        public TurnsController(CurrentWordModel currentWordModel)
        {
            this.currentWordModel = currentWordModel;
            errorsModel = new ErrorsModel();

            endGameController = new EndGameController(this.currentWordModel, errorsModel);
        }

        public void Turn(char letter)
        {
            // chnge view or change 

            var openedWord = currentWordModel.CheckLetterInWord(letter);

            if (openedWord)
            {
                // to do redraw
                Debug.Log($"you think there is a letter {letter} ???");

                Debug.Log(GetCurrentKnownWord());
            }
            else
            {
                var errors = errorsModel.ErrorDone();

                Debug.Log($"upsiiii you have made a mistake and you done {errors} mistakes looool");
                // to do redraw
            }

            if (currentWordModel.CheckGameWon() == errorsModel.AreErrorsLeft())
            {
                endGameController.GameEnd();
            }
        }

        private string GetCurrentKnownWord()
        {
            var result = "";

            for (int i = 0; i < currentWordModel.GetWord().Length; i++)
            {
                if (currentWordModel.GetOpenChars().Contains(i))
                    result += $"{currentWordModel.GetWord()[i]} ";
                else result += "_ ";
            }

            return result;
        }
    }
}
