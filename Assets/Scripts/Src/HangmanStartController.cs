using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class HangmanStartController : HangmanElement
    {
        private TurnsController turnsController;

        public CurrentWordModel currentWordModel;
        private AlphabetModel alphabetModel;

        public GameStatesView gameStatesView; // better be private

        public HangmanStartController(CurrentWordModel currentWordModel)
        {
            this.currentWordModel = currentWordModel;
            turnsController = new TurnsController(this.currentWordModel);

            alphabetModel = new AlphabetModel();

            gameStatesView = new GameStatesView(alphabetModel.GetAlphabet(), turnsController);
        }

        public void StartHangmanGame()
        {
            // send word.Lenght to View 
            // change UI state to game + init game state
            Debug.Log("Start turns");

            gameStatesView.InableKeyboard();
        }
    }
}
