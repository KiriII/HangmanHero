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

        public HangmanStartController(CurrentWordModel currentWordModel, GameStartController gameStartController)
        {
            this.currentWordModel = currentWordModel;
            turnsController = new TurnsController(this.currentWordModel);

            alphabetModel = new AlphabetModel();

            gameStatesView = new GameStatesView(alphabetModel.GetAlphabet(), turnsController, gameStartController);
            turnsController.SetGameStateView(gameStatesView);  // КОСТЫЛЬ
        }

        public void StartHangmanGame()
        {
            gameStatesView.StartGame(currentWordModel.GetWord().Length);
        }
    }
}
