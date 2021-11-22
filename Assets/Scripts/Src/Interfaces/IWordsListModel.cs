using System.Collections;

namespace HangmanHero
{
    public interface IWordsListModel
    {
        void RemoveUsedWord(string word);

        ArrayList getUnusedWords();
    }
}

