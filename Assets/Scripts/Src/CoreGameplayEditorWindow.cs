using System;
using UnityEditor;
using Src.HangmanCoreGameplay;
using Src.HangmanGame;
using Src.HangmanGameResult;
using Src.HangmanGameStatistic;
using UnityEngine;

public class CoreGameplayEditorWindow : EditorWindow
{
    private string _word;
    private string _symbol;

    private static HangmanGame _hangmanGame;
    
    [MenuItem("HangmanHero/CoreTest")]
    public static void ShowWindow()
    {
        GetWindow<CoreGameplayEditorWindow>("Core Gameplay Test");
    }
    
    private void OnGUI()
    {
        if (GUILayout.Button("RESET"))
        {
            _hangmanGame = new HangmanGame();
        }
        
        _word = EditorGUILayout.TextField("word", _word);

        if (GUILayout.Button("START GAME"))
        {
            _hangmanGame.StartGame(_word);
        }

        _symbol = EditorGUILayout.TextField("input char", _symbol);
        
        if (GUILayout.Button("MAKE TURN"))
        {
            _hangmanGame.Turn(_symbol[0]);
            Debug.Log(_hangmanGame.GetStatisticAsString());
        }
    }
}
