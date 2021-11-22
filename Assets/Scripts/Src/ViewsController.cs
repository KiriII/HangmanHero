using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class ViewsController
    {
        private GameStartController gameStartController;
        private TurnsController turnsController;

        private IAlphabetModel alphabetModel;

        private GameStatesView gameStatesView;
        private StartStateView startStateView;

        private bool won;

        public ViewsController(GameStartController gameStartController, ICurrentWordModel currentWordModel)
        {
            this.gameStartController = gameStartController;

            turnsController = new TurnsController(currentWordModel, this);

            alphabetModel = new AlphabetModel();

            startStateView = new StartStateView(this);

            gameStatesView = new GameStatesView(alphabetModel.GetAlphabet(), this);
        }

        // Input
        public void GameStartButtonPressed()
        {
            gameStartController.GameStart(won);
        }

        public void TurnsButtonPressed(char letter)
        {
            turnsController.Turn(letter);
        }

        // Update Views
        public void StartGameViewUpdate(int wordLength)
        {
            gameStatesView.StartGame(wordLength);
        }

        public void WordViewUpdate(ArrayList openWords, string word)
        {
            gameStatesView.UpdateWord(openWords, word);
        }

        public void HangmanViewUpdate(int errors)
        {
            gameStatesView.UpdateHangman(errors);
        }

        public void GameEndViewRedraw(int wins, int loses, bool won, string word)
        {
            this.won = won;

            gameStatesView.DisableKeyboard(won);
            gameStatesView.OpenAllLetters(word);
            gameStatesView.UpdateScore(wins, loses);
        }
    }
}
