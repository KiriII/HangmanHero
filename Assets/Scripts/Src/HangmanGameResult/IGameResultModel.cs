namespace Src.HangmanGameResult
{
    public interface IGameResultModel
    {
        bool IsErrorsRunOut(int currentErrorsCount);
    }
}