using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HangmanHero
{
    public class GameStatesView : HangmanElement
    {
        private TurnsController turnsController;
        private HangmanStartController hangmanStartController;

        private GameObject stateGame;

        //keyboard
        private Transform keyboardList;
        private GameObject keyboardItem;

        private Transform letterList;
        private GameObject letterItem;

        private Transform hangman;

        private GameObject score;

        private GameObject txtGameOver;
        private GameObject buttonRestart;

        private ArrayList lettersItemsList;
        private ArrayList errorsImages;

        public GameStatesView(ArrayList alphabet, TurnsController turnsController, GameStartController gameStartController)
        {
            this.turnsController = turnsController;
            this.hangmanStartController = hangmanStartController;

            stateGame = app.mainUI.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;

            keyboardList = stateGame.transform.GetChild(1).GetChild(0);
            keyboardItem = keyboardList.GetChild(0).gameObject;
            keyboardItem.SetActive(false);

            letterList = stateGame.transform.GetChild(0).GetChild(0);
            letterItem = letterList.GetChild(0).gameObject;
            letterItem.SetActive(false);

            hangman = stateGame.transform.GetChild(0).GetChild(1);

            score = stateGame.transform.GetChild(2).gameObject;

            txtGameOver = stateGame.transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
            buttonRestart = stateGame.transform.GetChild(1).GetChild(1).GetChild(1).gameObject;

            buttonRestart.transform.GetChild(0).gameObject.GetComponent<Text>().text = "ИГРАТЬ ЕЩЁ РАЗ";
            txtGameOver.GetComponent<Text>().text = "";
            buttonRestart.GetComponent<Button>().onClick.AddListener(() => gameStartController.GameStart());

            txtGameOver.SetActive(false);
            buttonRestart.SetActive(false);

            errorsImages = new ArrayList();

            foreach (Transform child in hangman)
            {
                errorsImages.Add(child.gameObject);
            }

            CreateKeyboard(alphabet);
            keyboardList.gameObject.SetActive(false);

            lettersItemsList = new ArrayList();

            UpdateScore(0, 0);
        }

        public void StartGame(int wordLenght)
        {
            stateGame.SetActive(true);
            InableKeyboard();
            ClearWordView();
            InitWord(wordLenght);
            ClearHangman();
        }

        // -------------------keyboard----------------------------
        public void CreateKeyboard(ArrayList alphabet)
        {
            foreach (var letter in alphabet)
            {
                var newKeyboardItem = Instantiate(keyboardItem, keyboardList);

                var key = newKeyboardItem.GetComponent<Button>();
                key.onClick.AddListener(() => turnsController.Turn((char)letter));

                newKeyboardItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = letter.ToString(); // bad need to change. like construct mb?
                newKeyboardItem.SetActive(true);
            }
        }

        public void InableKeyboard()
        {
            keyboardList.gameObject.SetActive(true);

            txtGameOver.SetActive(false);
            buttonRestart.SetActive(false);
        }

        public void DisableKeyboard()
        {
            keyboardList.gameObject.SetActive(false);

            txtGameOver.SetActive(true);
            buttonRestart.SetActive(true);
        }

        // -------------------current word----------------------------

        public void InitWord(int wordLenght)
        {
            for (int i = 0; i < wordLenght; i++)
            {
                var newLetterItem = Instantiate(letterItem, letterList);

                newLetterItem.transform.GetChild(1).gameObject.GetComponent<Text>().text = "_"; // bad need to change. like construct mb?
                newLetterItem.SetActive(true);

                lettersItemsList.Add(newLetterItem);
            }
        }

        public void UpdateWord(ArrayList openWords, string word)
        {
            foreach (var letterNumber in openWords)
            {
                var letterGameObject = (GameObject)lettersItemsList[(int)letterNumber];    // bad
                letterGameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = word[(int)letterNumber].ToString(); // bad need to change. like construct mb?
            }
        }

        public void ClearWordView()
        {
            foreach (var letterItem in lettersItemsList)
            {
                Destroy((GameObject)letterItem);
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
            score.GetComponent<Text>().text = $"Выиграно: {wins}. Проиграно:{loses} .";
        }
    }
}
