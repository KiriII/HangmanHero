using System;
using Src.HangmanCoreGameplay;
using Src.HangmanGameResult;
using Src.HangmanGameStatistic;
using UnityEngine;

namespace Src.HangmanGame
{
    public class GameInProgressState : HangmanState
    {
        private HangmanGameCore _hangmanGameCore;
        
        public GameInProgressState(string word, IHangmanGameResult hangmanGameResult)
        {
            _hangmanGameCore = new HangmanGameCore(word);
            hangmanGameResult.StartNewGame(_hangmanGameCore);
        }
        
        public override void Turn(char symbol)
        {
            _hangmanGameCore.Turn(symbol);
        }

        public override void StartGame(string word, IHangmanGameResult hangmanGameResult)
        {
            
        }

        public override void FinishGame(HangmanGameFinishedState hangmanGameFinishedState, IHangmanGamesStatistic hangmanGamesStatistic)
        {
            hangmanGamesStatistic.UpdateStatistic(hangmanGameFinishedState);
            _hangmanGame.ChangeGameState(new GameFinishedState());
        }
    }
}