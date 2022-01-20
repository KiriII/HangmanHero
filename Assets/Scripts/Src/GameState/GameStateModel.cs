namespace Src.GameState
{
    public class GameStateModel
    {
        private HangmanGameState _currentGameState;

        public GameStateModel()
        {
            _currentGameState = HangmanGameState.Undefined;
        }

        public GameStateModel(HangmanGameState gameState)
        {
            _currentGameState = gameState;
        }
        
        public void SetCurrentState(HangmanGameState gameState)
        {
            _currentGameState = gameState;
        }
        
        public HangmanGameState GetCurrentState()
        {
            return _currentGameState;
        }
    }
}