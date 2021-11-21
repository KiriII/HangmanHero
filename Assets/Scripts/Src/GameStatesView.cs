using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace HangmanHero
{
    public class GameStatesView : HangmanElement
    {
        private ViewsController viewsController;

        private TextsModel textsModel;

        private GameObject stateGame;

        private Transform keyboardList;
        private GameObject keyboardItem;

        private Transform letterList;
        private GameObject letterItem;

        private Transform hangman;

        private GameObject score;

        private GameObject gameStateRestart;
        private GameObject txtGameOver;
        private GameObject buttonRestart;

        private ArrayList lettersItemsList;
        private ArrayList errorsImages;

        public GameStatesView(ArrayList alphabet, ViewsController viewsController)
        {
            this.viewsController = viewsController;
            textsModel = app.textsModel;

            lettersItemsList = new ArrayList();
            errorsImages = new ArrayList();

            InitGameObjects();
            SetTextes();
            CreateKeyboard(alphabet);
            UpdateScore(0, 0);

            buttonRestart.GetComponent<Button>().onClick.AddListener(() => viewsController.GameStartButtonPressed());
        }

        public void StartGame(int wordLenght)
        {
            stateGame.SetActive(true);
            InableKeyboard();
            ClearWordView();
            InitWord(wordLenght);
            ClearHangman();
        }

        private void InitGameObjects()
        {
            stateGame = app.mainUI.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;

            keyboardList = stateGame.transform.GetChild(1).GetChild(0);
            keyboardItem = keyboardList.GetChild(0).gameObject;
            keyboardItem.SetActive(false);

            letterList = stateGame.transform.GetChild(0).GetChild(0);
            letterItem = letterList.GetChild(0).gameObject;
            letterItem.SetActive(false);

            hangman = stateGame.transform.GetChild(0).GetChild(1);

            score = stateGame.transform.GetChild(2).gameObject;

            gameStateRestart = stateGame.transform.GetChild(1).GetChild(1).gameObject;
            txtGameOver = gameStateRestart.transform.GetChild(0).gameObject;
            buttonRestart = gameStateRestart.transform.GetChild(1).gameObject;

            foreach (Transform child in hangman)
            {
                errorsImages.Add(child.gameObject);
            }
        }

        private void SetTextes()
        {
            buttonRestart.transform.GetChild(0).gameObject.GetComponent<Text>().text = textsModel.GetTextByKey("buttonGameRestart");
        }

        // -------------------keyboard----------------------------
        public void CreateKeyboard(ArrayList alphabet)
        {
            foreach (var letter in alphabet)
            {
                var newKeyboardItem = Instantiate(keyboardItem, keyboardList);

                var key = newKeyboardItem.GetComponent<Button>();
                key.onClick.AddListener(() => viewsController.TurnsButtonPressed((char)letter));

                newKeyboardItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = letter.ToString(); // bad need to change. like construct mb?
                newKeyboardItem.SetActive(true);
            }
        }

        public void InableKeyboard()
        {
            keyboardList.gameObject.SetActive(true);
            gameStateRestart.SetActive(false);
        }

        public void DisableKeyboard(bool won)
        {
            keyboardList.gameObject.SetActive(false);
            txtGameOver.GetComponent<Text>().text = won ? textsModel.GetTextByKey("winText") : textsModel.GetTextByKey("loseText");
            gameStateRestart.SetActive(true);
        }

        // -------------------current word----------------------------

        public void InitWord(int wordLenght)
        {
            for (int i = 0; i < wordLenght; i++)
            {
                var newLetterItem = Instantiate(letterItem, letterList);

                newLetterItem.transform.GetChild(1).gameObject.GetComponent<Text>().text = textsModel.GetTextByKey("unknownLetter"); // bad need to change. like construct mb?
                newLetterItem.SetActive(true);

                lettersItemsList.Add(newLetterItem);
            }
        }

        public void UpdateWord(ArrayList openWords, string word)
        {
            foreach (int letterNumber in openWords)
            {
                var letterGameObject = (GameObject)lettersItemsList[letterNumber];    // bad
                letterGameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = word[letterNumber].ToString(); // bad need to change. like construct mb?
            }
        }

        public void OpenAllLetters(string word)
        {
            var lettersIndex = new ArrayList();

            for (int i = 0; i < word.Length; i++)
            {
                lettersIndex.Add(i);
            }

            UpdateWord(lettersIndex, word);
        }

        public void ClearWordView()
        {
            foreach (GameObject letterItem in lettersItemsList)
            {
                Destroy(letterItem);
            }
            lettersItemsList.Clear();
        }

        // -------------------Hangman----------------------------

        public void UpdateHangman(int errorCount)
        {
            var image = (GameObject)errorsImages[errorCount];
            image.SetActive(true);
        }

        public void ClearHangman()
        {
            foreach (GameObject image in errorsImages)
            {
                image.SetActive(false);
            }
        }

        // -------------------Score----------------------------

        public void UpdateScore(int wins, int loses)
        {
            var scoreText = textsModel.GetTextByKey("score");
            scoreText = scoreText.Replace("{wins}", wins.ToString());
            scoreText = scoreText.Replace("{loses}", loses.ToString());
            score.GetComponent<Text>().text = scoreText;
        }
    }
}
