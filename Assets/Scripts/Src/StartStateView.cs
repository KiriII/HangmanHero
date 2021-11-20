using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HangmanHero
{
    public class StartStateView : HangmanElement
    {
        private GameStartController gameStartController;

        private GameObject stateStart;

        private GameObject txtHead;
        private GameObject txtRules;
        private GameObject buttonStart;

        public StartStateView(GameStartController gameStartController)
        {
            this.gameStartController = gameStartController;

            stateStart = app.mainUI.transform.GetChild(0).GetChild(1).GetChild(0).gameObject; // baad
            stateStart.SetActive(true);

            txtHead = app.mainUI.transform.GetChild(0).GetChild(0).gameObject;
            txtRules = stateStart.transform.GetChild(0).GetChild(0).gameObject;
            buttonStart = stateStart.transform.GetChild(2).gameObject;

            txtHead.GetComponent<Text>().text = "Игра ВИСЕЛИЦА";
            buttonStart.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Играть";

            buttonStart.GetComponent<Button>().onClick.AddListener(() =>
                {
                    gameStartController.GameStart();
                    DisableScreen();
                });
        }

        public void DisableScreen()
        {
            stateStart.SetActive(false);
        }
    }
}
