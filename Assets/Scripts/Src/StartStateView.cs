using UnityEngine.UI;
using UnityEngine;

namespace HangmanHero
{
    public class StartStateView : HangmanElement
    {
        private ViewsController viewsController;

        private TextsModel textsModel;

        private GameObject stateStart;

        private GameObject txtHead;
        private GameObject txtRules;
        private GameObject txtButtonStart;

        private GameObject buttonStart;

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
        }

        private void InitGameObjects()
        {
            stateStart = app.mainUI.transform.GetChild(0).GetChild(1).GetChild(0).gameObject; // baad
            stateStart.SetActive(true);

            txtHead = app.mainUI.transform.GetChild(0).GetChild(0).gameObject;
            txtRules = stateStart.transform.GetChild(0).GetChild(0).gameObject;
            buttonStart = stateStart.transform.GetChild(2).gameObject;
            txtButtonStart = buttonStart.transform.GetChild(0).gameObject;
        }

        private void SetTextes()
        {
            txtHead.GetComponent<Text>().text = textsModel.GetTextByKey("head");
            txtButtonStart.GetComponent<Text>().text = textsModel.GetTextByKey("buttonGameStart");
            txtRules.GetComponent<Text>().text = textsModel.GetTextByKey("rules");
        }


        private void DisableScreen()
        {
            stateStart.SetActive(false);
        }
    }
}
