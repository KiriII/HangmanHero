using System.Collections;
using System.Collections.Generic;
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

        public int[] CheckLetterInWord(char letter)
        {
            //openChars.Add(openChars.Count);
            //return new int[1] { openChars.Count };
            // TO DO

            return new int[0] {};
        }

        public bool CheckGameWon()
        {
            if (openChars.Count == word.Length)
            {
                //Debug.Log("true");
                return true;
            }
            //Debug.Log("false"); 
            return false;
        }

        public void Reset() 
        {
            openChars.Clear();
        }

        // getters 

        public ArrayList GetOpenChars()   // better not use 
        {
            return openChars;
        }

        public string GetWord()
        {
            return word;
        }

        public void SetWord(string word)
        {
            this.word = word;
            Debug.Log($"psssst word is {word}");    //   -----------------

            var emptyWord = "";                     //
            for (int i = 0; i < word.Length; i++)   // 
            {
                emptyWord += "_ ";                  //    DELETE
            }

            Debug.Log($"Угадай слово {emptyWord}"); // ------------------
        }
    }
}
