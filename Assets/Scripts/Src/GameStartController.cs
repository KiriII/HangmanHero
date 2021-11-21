using System.Collections;

namespace HangmanHero
{
    public class GameStartController
    {
        private ViewsController viewsController;

        private GameModel gameModel;
        private CurrentWordModel currentWordModel;

        public GameStartController()
        {
            gameModel = new GameModel();
            currentWordModel = new CurrentWordModel();

            viewsController = new ViewsController(this, currentWordModel);
        }

        public void GameStart(bool won = false)
        {
            var word = currentWordModel.GetWord();

            if (won)
            {
                gameModel.RemoveUsedWord(word);

            }

            // Debug.Log($"Оставшиеся неодгаданные слова: {string.Join(", ", gameModel.getUnusedWords().Cast<string>().ToArray())}");

            currentWordModel.SetWord(RandomWord(word));
            viewsController.StartGameViewUpdate(currentWordModel.GetWord().Length);
        }

        private string RandomWord(string word)
        {
            var words = new ArrayList(gameModel.getUnusedWords());   // unused words, not all
            words.Remove(word);

            // Debug.Log($"Оставшиеся неодгаданные неповторяющиеся слова: {string.Join(", ", words.Cast<string>().ToArray())}");

            System.Random rnd = new System.Random();
            return (string)words[rnd.Next(words.Count)];
        }
    }
}
