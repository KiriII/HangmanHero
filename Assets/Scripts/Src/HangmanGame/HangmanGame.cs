using System;
using Src.GameState;
using Src.HangmanCoreGameplay;
using Src.HangmanGameResult;
using Src.HangmanGameStatistic;

namespace Src.HangmanGame
{
    public class HangmanGame : IHangmanGame
    {
        private HangmanGameCore _hangmanGameCore;
        private HangmanGamesResult _hangmanGameResult;
        private HangmanState _gameState;
        private HangmanGamesStatistic _hangmanGamesStatistic;

        private GameRule _gameRule;

        public HangmanGame()
        {
            _gameState = new HangmanState();
            _hangmanGamesStatistic = new HangmanGamesStatistic();
            _gameRule = new GameRule();
        }

        public void StartGame(String word)
        {
            _gameState.StartGame();
            InitCoreGameplayElements(word);
            AddActionsListeners();
        }

        private void InitCoreGameplayElements(String word)
        {
            _hangmanGameCore = new HangmanGameCore(word);
            _hangmanGameResult = new HangmanGamesResult(_hangmanGameCore, _gameRule);
        }

        private void AddActionsListeners()
        {
            _hangmanGameResult.EnableGameStateChangedListener(_gameState.EndGame);
            _hangmanGameResult.EnableGameStateChangedListener(_hangmanGamesStatistic.UpdateStatistic);
        }

        public void Turn(char inputSymbol)
        {
            _hangmanGameCore.Turn(inputSymbol);
        }
    }
}