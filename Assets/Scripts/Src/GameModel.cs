using System.Collections;

namespace HangmanHero
{
    // Actualy better call it's like WordsListModel
    public class GameModel : IWordsListModel
    {
        private ArrayList allKnownWords;
        private ArrayList unusedWords;

        public GameModel()
        {
            var wordXMLParser = new WordsXMLParser();

            allKnownWords = wordXMLParser.GetAllKnownWords();
            if (!CheckDataNotNull(allKnownWords))
            {
                throw new System.Exception("Ошибка при чтении входных данных");
            }

            unusedWords = new ArrayList(allKnownWords);
        }

        public void RemoveUsedWord(string word)
        {
            if (unusedWords.Count == 1)
            {
                unusedWords = new ArrayList(allKnownWords);
            }
            else if (unusedWords.Count > 1)
            {
                unusedWords.Remove(word);
            } else
            {
                throw new System.Exception("Ошибка при обновлении списка неиспользованных слов");
            }
        }

        private bool CheckDataNotNull(ArrayList words)
        {
            if (words?.Count > 0)
            {
                return true;
            }
            return false;
        }

        // getters
        public ArrayList getUnusedWords()
        {
            return unusedWords;
        }
    }
}
