using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HangmanHero
{
    public class GameStatesView : MonoBehaviour
    {
        private TurnsController turnsController;

        private GameObject gameState;
        private Transform keyboardList;
        private GameObject keyboardItem;

        public GameStatesView(ArrayList alphabet, TurnsController turnsController)
        {
            this.turnsController = turnsController;

            keyboardItem = GameObject.Find("KeyboardItem");
            keyboardItem.SetActive(false);
            keyboardList = GameObject.Find("GameStateKeyboard").transform;

            CreateKeyboard(alphabet);
            keyboardList.gameObject.SetActive(false);
        }

        public void CreateKeyboard(ArrayList alphabet)
        {
            foreach (var letter in alphabet)
            {
                var newKeyboardItem = Instantiate(keyboardItem, keyboardList);

                var key = newKeyboardItem.GetComponent<Button>();
                key.onClick.AddListener(() => turnsController.Turn((char)letter));

                newKeyboardItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = letter.ToString();
                newKeyboardItem.SetActive(true);
            }
        }

        public void InableKeyboard()
        {
            keyboardList.gameObject.SetActive(true);
        }

        public void DisableKeyboard()
        {
            keyboardList.gameObject.SetActive(false);
        }


    }
}
