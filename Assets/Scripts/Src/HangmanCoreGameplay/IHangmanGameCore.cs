namespace Src.HangmanCoreGameplay
{
    public interface IHangmanGameCore
    {
        void Turn(char inputSymbol);

        void PrintModelState();
    }
}