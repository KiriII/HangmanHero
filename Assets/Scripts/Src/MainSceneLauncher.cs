using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HangmanHero
{
    public class MainSceneLauncher : MonoBehaviour
    {
        [SerializeField] public GameObject mainUI;
        public GameStartController gameStartController;
        private TextsModel textsModel;

        public bool won;

        private void Start()
        {
            // Game Start to do
            won = false;
            gameStartController = new GameStartController();

            // debug
            textsModel = new TextsModel();
        }
    }

    public class HangmanElement : MonoBehaviour
    {
        // Gives access to the application and all instances.
        public MainSceneLauncher app { get { return GameObject.FindObjectOfType<MainSceneLauncher>(); } }
    }
}
