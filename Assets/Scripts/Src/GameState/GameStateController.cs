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
            if (!_gameStateModel.CheckCurrentGameStateEquals(HangmanGameState.GameInProgress))
            {
                _gameStateModel.SetCurrentState(HangmanGameState.GameInProgress);
            }
        }

        public void EndGame(HangmanGameState endGameState)
        {
            if (_gameStateModel.CheckCurrentGameStateEquals(HangmanGameState.GameInProgress))
            {
                _gameStateModel.SetCurrentState(endGameState);
            }
        }
    }
}