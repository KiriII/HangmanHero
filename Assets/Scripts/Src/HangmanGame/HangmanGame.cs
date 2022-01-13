using Src.HangmanGameResult;
using Src.HangmanGameStatistic;
using UnityEngine;

namespace Src.HangmanGame
{
    public class HangmanGame : IHangmanGame
    {
        private IHangmanGamesStatistic _hangmanGamesStatistic;
        private IHangmanGameResult _hangmanGameResult;

        private HangmanState _hangmanState;

        public HangmanGame()
        {
            ChangeGameState(new GameFinishedState());
            
            InitHangmanApis();
        }

        public void ChangeGameState(HangmanState hangmanState)
        {
            _hangmanState = hangmanState;
            _hangmanState.SetHangmanGame(this);
        }

        private void InitHangmanApis()
        {
            _hangmanGamesStatistic = new HangmanGamesStatistic();
            _hangmanGameResult = new HangmanGamesResult();
            _hangmanGameResult.EnableGameStateChangedListener(FinishGame);
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
            _hangmanState.FinishGame(hangmanGameFinishedState, _hangmanGamesStatistic);
        }

        //---------------debug--------------

        public string GetStatisticAsString()
        {
            var wins = _hangmanGamesStatistic.GetWinsCount();
            var loses = _hangmanGamesStatistic.GetLosesCount();
            return $"wins = {wins} loses = {loses}";
        }

    }
}