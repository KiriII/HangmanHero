using System;
using Src.HangmanGameResult;
using Src.HangmanGameStatistic;

namespace Src.HangmanGame
{
    public abstract class HangmanState
    {
        protected HangmanGame _hangmanGame;

        public void SetHangmanGame(HangmanGame hangmanGame)
        {
            _hangmanGame = hangmanGame;
        }
        
        public abstract void Turn(char symbol);

        public abstract void StartGame(string word, IHangmanGameResult hangmanGameResult);

        public abstract void FinishGame(HangmanGameFinishedState hangmanGameFinishedState, IHangmanGamesStatistic hangmanGamesStatistic);
    }
}