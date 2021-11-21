using System.Collections;
using UnityEngine;

namespace HangmanHero
{
    public class CurrentWordModel
    {

        private ArrayList openChars;
        private string word;

        public CurrentWordModel()
        {
            openChars = new ArrayList();
        }

        public bool CheckLetterInWord(char letter)
        {
            var haveLetter = false;

            for (int i = word.IndexOf(letter); i > -1; i = word.IndexOf(letter, i + 1))
            {

                if (!openChars.Contains(i))
                {
                    openChars.Add(i);
                }

                haveLetter = true;
            }

            return haveLetter;
        }

        public bool CheckGameWon()
        {
            if (openChars.Count == word.Length)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            openChars.Clear();
        }

        // getters 

        public ArrayList GetOpenChars()
        {
            return openChars;
        }

        public string GetWord()
        {
            return word;
        }

        public void SetWord(string word)
        {
            if (word?.Length == 0)
            {
                throw new System.Exception("Ошибка при задании слова. Длина слова = 0");
            }
            this.word = word;
            if (Constants.currentWordDebugLog)
            {
                Debug.Log($"Current word is {word}");
            }
        }
    }
}
