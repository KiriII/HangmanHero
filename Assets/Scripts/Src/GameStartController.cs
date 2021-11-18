using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HangmanHero
{
    public class GameStartController 
    { 
        public HangmanStartController hangmanStartController; // better be private

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
            var word = currentWordModel.GetWord();

            if (won)
            {
                gameModel.RemoveUsedWord(word); 

            }

            Debug.Log($"Оставшиеся неодгаданные слова: {string.Join(", ", gameModel.getUnusedWords().Cast<string>().ToArray())}");

            // check words not empty

            currentWordModel.SetWord(RandomWord(word));
            hangmanStartController.StartHangmanGame();
        }

        private string RandomWord(string word)
        {
            var words = new ArrayList(gameModel.getUnusedWords());   // unused words, not all
            words.Remove(word);

            Debug.Log($"Оставшиеся неодгаданные неповторяющиеся слова: {string.Join(", ", words.Cast<string>().ToArray())}");

            System.Random rnd = new System.Random();
            return (string)words[rnd.Next(words.Count)];
        }
    }
}
