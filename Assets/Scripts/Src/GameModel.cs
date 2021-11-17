using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class GameModel
    {
        private ArrayList allKnownWords;
        private ArrayList unusedWords;

        public GameModel()
        {
            var wordXMLParser = new WordsXMLParser();

            allKnownWords = wordXMLParser.GetAllKnownWords(); 
            unusedWords = new ArrayList(allKnownWords);

            if (!CheckDataNotNull(allKnownWords))
            {
                throw new System.Exception("Ошибка при чтении входных данных");
            }
        }

        public void RemoveUsedWord(string word)
        {
            if (unusedWords.Count == 1)
            {
                unusedWords = allKnownWords;
            }
            else
            {
                unusedWords.Remove(word);
            }
        }

        private bool CheckDataNotNull(ArrayList words)
        {
            if (words?.Count > 0)
            {
                return true;
            }
            return false;
        }

        // getters
        public ArrayList getUnusedWords()
        {
            return unusedWords;
        }
    }
}
