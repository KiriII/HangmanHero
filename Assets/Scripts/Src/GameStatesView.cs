using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace HangmanHero
{
    public class GameStatesView : HangmanElement
    {
        private ViewsController viewsController;

        private ITextModel textsModel;

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

        private const string startGameObjectName = "StateGame";
        private const string gameStateKeyboardObjectName = "GameStateKeyboard";
        private const string letterListObjectName = "LetterList";
        private const string hangmanObjectName = "Hangman";
        private const string txtStatusObjectName = "TxtStatus";
        private const string gameStateRestartObjectName = "GameStateRestart";

        //text keys
        private const string buttonGameRestartKey = "buttonGameRestart";
        private const string winTextKey = "winText";
        private const string loseTextKey = "loseText";
        private const string unknownLetterKey = "unknownLetter";
        private const string scoreKey = "score";

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

        // Need to do it better
        private void InitGameObjects()
        {
            stateGame = GameObjectFinder.FindObject(app.mainUI, startGameObjectName);

            keyboardList = GameObjectFinder.FindObject(stateGame, gameStateKeyboardObjectName).transform;
            keyboardItem = keyboardList.GetComponentsInChildren<Button>()[0].gameObject;
            keyboardItem.SetActive(false);

            letterList = GameObjectFinder.FindObject(stateGame, letterListObjectName).transform;
            letterItem = letterList.GetChild(0).gameObject;
            letterItem.SetActive(false);

            hangman = GameObjectFinder.FindObject(stateGame, hangmanObjectName).transform; 

            score = GameObjectFinder.FindObject(stateGame, txtStatusObjectName);

            gameStateRestart = GameObjectFinder.FindObject(stateGame, gameStateRestartObjectName); 
            txtGameOver = gameStateRestart.GetComponentsInChildren<Text>()[0].gameObject;
            buttonRestart = gameStateRestart.GetComponentsInChildren<Button>()[0].gameObject;

            foreach (Transform child in hangman)
            {
                errorsImages.Add(child.gameObject);
            }
        }

        private void SetTextes()
        {
            buttonRestart.GetComponentsInChildren<Text>()[0].text = textsModel.GetTextByKey(buttonGameRestartKey);
        }

        // -------------------keyboard----------------------------
        public void CreateKeyboard(ArrayList alphabet)
        {
            foreach (var letter in alphabet)
            {
                var newKeyboardItem = Instantiate(keyboardItem, keyboardList);

                newKeyboardItem.GetComponent<Button>().onClick.AddListener(() => viewsController.TurnsButtonPressed((char)letter));

                newKeyboardItem.GetComponentsInChildren<Text>()[0].text = letter.ToString();
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
            txtGameOver.GetComponent<Text>().text = won ? textsModel.GetTextByKey(winTextKey) : textsModel.GetTextByKey(loseTextKey);
            gameStateRestart.SetActive(true);
        }

        // -------------------current word----------------------------

        public void InitWord(int wordLenght)
        {
            for (int i = 0; i < wordLenght; i++)
            {
                var newLetterItem = Instantiate(letterItem, letterList);

                newLetterItem.GetComponentsInChildren<Text>()[0].text = textsModel.GetTextByKey(unknownLetterKey); 
                newLetterItem.SetActive(true);

                lettersItemsList.Add(newLetterItem);
            }
        }

        public void UpdateWord(ArrayList openWords, string word)
        {
            foreach (int letterNumber in openWords)
            {
                var letterGameObject = (GameObject)lettersItemsList[letterNumber];   
                letterGameObject.GetComponentsInChildren<Text>()[0].text = word[letterNumber].ToString(); 
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
            var scoreText = textsModel.GetTextByKey(scoreKey);
            scoreText = scoreText.Replace("{wins}", wins.ToString());
            scoreText = scoreText.Replace("{loses}", loses.ToString());
            score.GetComponent<Text>().text = scoreText;
        }
    }
}
