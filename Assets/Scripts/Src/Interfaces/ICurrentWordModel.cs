using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HangmanHero
{
    public interface ICurrentWordModel
    {

        bool CheckLetterInWord(char letter);

        bool CheckGameWon();

        void Reset();

        ArrayList GetOpenChars();

        string GetWord();

        void SetWord(string word);
    }
}