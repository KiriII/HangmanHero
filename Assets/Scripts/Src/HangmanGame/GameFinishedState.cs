using System;
using Src.HangmanGameResult;
using Src.HangmanGameStatistic;
using UnityEngine;

namespace Src.HangmanGame
{
    public class GameFinishedState : HangmanState
    {
        public override void Turn(char symbol)
        {
            
        }

        public override void StartGame(string word, IHangmanGameResult hangmanGameResult)
        {
            _hangmanGame.ChangeGameState(new GameInProgressState(word, hangmanGameResult));
        }

        public override void FinishGame(HangmanGameFinishedState hangmanGameFinishedState, IHangmanGamesStatistic hangmanGamesStatistic)
        {
            
        }
    }
}