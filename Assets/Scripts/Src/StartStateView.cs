using UnityEngine.UI;
using UnityEngine;

namespace HangmanHero
{
    public class StartStateView : HangmanElement
    {
        private ViewsController viewsController;

        private ITextModel textsModel;

        private GameObject stateStart;

        private GameObject txtHead;
        private GameObject txtRules;
        private GameObject txtButtonStart;

        private GameObject buttonStart;

        private const string stateStartObjectName = "StateStart";

        //text keys
        private const string headTextKey = "head";
        private const string buttonStartTextKey = "buttonGameStart";
        private const string rulesTextKey = "rules";

        public StartStateView(ViewsController viewsController)
        {
            this.viewsController = viewsController;

            textsModel = app.textsModel;

            InitGameObjects();
            SetTextes();

            buttonStart.GetComponent<Button>().onClick.AddListener(() =>
                {
                    viewsController.GameStartButtonPressed();
                    DisableScreen();
                });

            stateStart.SetActive(true);
        }

        private void InitGameObjects()
        {
            stateStart = GameObjectFinder.FindObject(app.mainUI, stateStartObjectName); 

            txtHead = app.mainUI.GetComponentsInChildren<Text>()[0].gameObject;
            txtRules = stateStart.GetComponentsInChildren<Text>()[0].gameObject;
            buttonStart = stateStart.GetComponentsInChildren<Button>()[0].gameObject;
            txtButtonStart = buttonStart.GetComponentsInChildren<Text>()[0].gameObject;
        }

        private void SetTextes()
        {
            txtHead.GetComponent<Text>().text = textsModel.GetTextByKey(headTextKey);
            txtButtonStart.GetComponent<Text>().text = textsModel.GetTextByKey(buttonStartTextKey);
            txtRules.GetComponent<Text>().text = textsModel.GetTextByKey(rulesTextKey);
        }


        private void DisableScreen()
        {
            stateStart.SetActive(false);
        }
    }
}
