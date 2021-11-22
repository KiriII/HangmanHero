using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public class AlphabetModel : IAlphabetModel
    {
        private ArrayList alphabet;

        public AlphabetModel()
        {
            alphabet = new ArrayList();

            GetRussianAlphabet(ref alphabet);
            
            if (alphabet.Count == 0)
            {
                throw new System.Exception("Ошибка при создании алфавита");
            }
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
