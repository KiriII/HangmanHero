namespace Src.GameState
{
    public class GameStateController
    {
        private GameStateModel _gameStateModel;

        public GameStateController(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }

        public void StartGame()
        {
            if (CheckGameCanStart())
            {
                _gameStateModel.SetCurrentState(HangmanGameState.GameInProgress);
            }
        }

        private bool CheckGameCanStart()
        {
            var currentGameState = _gameStateModel.GetCurrentState();
            return currentGameState != HangmanGameState.GameInProgress;
        }

        public void EndGame(HangmanGameState endGameState)
        {
            if (CheckGameCanEnd(endGameState))
            {
                _gameStateModel.SetCurrentState(endGameState);
            }
        }

        private bool CheckGameCanEnd(HangmanGameState endGameState)
        {
            var currentGameState = _gameStateModel.GetCurrentState();
            if ((currentGameState != HangmanGameState.GameInProgress) ||
                (endGameState == HangmanGameState.Undefined || endGameState == HangmanGameState.GameInProgress))
                return false;
            return true;
        }
    }
}