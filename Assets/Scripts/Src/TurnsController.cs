using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class TurnsController 
    {

        private CurrentWordModel currentWordModel;
        private ErrorsModel errorsModel;

        private EndGameController endGameController;

        public TurnsController(CurrentWordModel currentWordModel)
        {
            this.currentWordModel = currentWordModel;
            errorsModel = new ErrorsModel();

            endGameController = new EndGameController(this.currentWordModel, errorsModel);
        }

        public void PlayGame()
        {
            // init input letters 
            Debug.Log($"Game End {currentWordModel.CheckGameWon()}");
            while (currentWordModel.CheckGameWon() != errorsModel.AreErrorsLeft())
            {
                Turn('a'); // debug
            }

            Debug.Log($"Game End {currentWordModel.CheckGameWon()} {errorsModel.AreErrorsLeft()}");
            endGameController.GameEnd();
        }

        private void Turn(char letter)
        {
            // chnge view or change 

            var openedWord = currentWordModel.CheckLetterInWord(letter);

            if (openedWord.Length > 0)
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
        }

        /*void Update()
        {
            if (!string.IsNullOrEmpty(word))
            {
                //Debug.Log(word);
                if (Input.GetKeyDown("up"))
                {
                    openChars.Add(openChars.Count);

                    Debug.Log($"Right! Only {errorsLeft} left");
                    Debug.Log($"{GetCurrentKnownWord()}");
                }

                if (Input.GetKeyDown("down"))
                {
                    errorsLeft--;
                    Debug.Log($"Not right. Only {errorsLeft} left");
                    Debug.Log($"{GetCurrentKnownWord()}");
                }
            }
        }*/

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
