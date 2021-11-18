using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class AlphabetModel
    {
        private ArrayList alphabet;

        public AlphabetModel()
        {
            alphabet = new ArrayList();

            GetRussianAlphabet(ref alphabet);
            
        }

        private void GetRussianAlphabet(ref ArrayList alphabet)
        {
            for (int i = Constants.ruAlphabetStart; i < Constants.ruAlphabetEnd; i++)
            {
                alphabet.Add((char)i);
                //добавляем Ё
                if (i == Constants.ruAlphabetExceptionStart)
                    alphabet.Add((char)Constants.ruAlphabetExceptionSourse);
            }
        }

        // getters
        public ArrayList GetAlphabet()
        {
            return alphabet;
        }
    }
}
