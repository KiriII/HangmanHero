namespace Src.HangmanGame
{
    public interface IHangmanGame
    {
        void Turn(char symbol);
        void StartGame(string word);
    }
}