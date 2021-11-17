using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HangmanHero
{
    public class GameStartController 
    { 
        private HangmanStartController hangmanStartController;

        private GameModel gameModel;
        private CurrentWordModel currentWordModel;

        public GameStartController()
        {
            gameModel = new GameModel();
            currentWordModel = new CurrentWordModel();
            hangmanStartController = new HangmanStartController(currentWordModel);

            // init view + input 
            Debug.Log($"The game has begun!");
        }

        public void GameStart(bool won = false)   // вызывается в input
        {
            if (won)
            {
                gameModel.RemoveUsedWord(hangmanStartController.currentWordModel.GetWord());  // bad

            }

            Debug.Log($"Оставшиеся неодгаданные слова: {string.Join(", ", gameModel.getUnusedWords().Cast<string>().ToArray())}");

            // check words not empty
            currentWordModel.SetWord(RandomWord());
            hangmanStartController.StartHangmanGame();
        }

        private string RandomWord()
        {
            var words = gameModel.getUnusedWords();   // unused words, not all

            System.Random rnd = new System.Random();
            return (string)words[rnd.Next(words.Count)];
        }
    }
}
