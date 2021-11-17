using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class HangmanStartController 
    {
        private TurnsController turnsController;

        public CurrentWordModel currentWordModel; 

        public HangmanStartController(CurrentWordModel currentWordModel)
        {
            this.currentWordModel = currentWordModel;
            turnsController = new TurnsController(this.currentWordModel);
        }

        public void StartHangmanGame()
        {
            // send word.Lenght to View 
            // change UI state to game + init game state
            Debug.Log("Start turns");
            turnsController.PlayGame();
        }
    }
}
