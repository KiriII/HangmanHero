namespace Src.GameState
{
    public class GameState : IGameState , ICurrentGameState
    {
        private GameStateModel _gameStateModel;
        private GameStateController _gameStateController;

        public GameState()
        {
            _gameStateModel = new GameStateModel();
            _gameStateController = new GameStateController(_gameStateModel);
        }

        public void StartGame()
        {
            _gameStateController.StartGame();
        }

        public void EndGame(HangmanGameState gameState)
        {
            _gameStateController.EndGame(gameState);
        }

        public HangmanGameState GetCurrentGameState()
        {
            return _gameStateModel.GetCurrentState();
        }
    }
}