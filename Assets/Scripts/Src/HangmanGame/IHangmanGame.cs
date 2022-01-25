using System;

namespace Src.HangmanGame
{
    public interface IHangmanGame
    {
        void StartGame(String word);
        void Turn(char inputSymbol);
    }
}