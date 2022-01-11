using Src.HangmanGameResult;
using Src.HangmanGameStatistic;
using UnityEngine;

namespace Src.HangmanGame
{
    public class HangmanGame : IHangmanGame
    {
        public IHangmanGamesStatistic hangmanGamesStatistic;
        private IHangmanGameResult _hangmanGameResult;

        private HangmanState _hangmanState;

        public HangmanGame()
        {
            ChangeGameState(new GameFinishedState());
            
            hangmanGamesStatistic = new HangmanGamesStatistic();
            _hangmanGameResult = new HangmanGamesResult();
            _hangmanGameResult.EnableGameStateChangedListener(FinishGame);
        }

        public void ChangeGameState(HangmanState hangmanState)
        {
            _hangmanState = hangmanState;
            _hangmanState.SetHangmanGame(this);
        }
        
        public void Turn(char symbol)
        {
            _hangmanState.Turn(symbol);
        }

        public void StartGame(string word)
        {
            _hangmanState.StartGame(word, _hangmanGameResult);
        }

        private void FinishGame(HangmanGameFinishedState hangmanGameFinishedState)
        {
            _hangmanState.FinishGame(hangmanGameFinishedState, hangmanGamesStatistic);
        }
    }
}