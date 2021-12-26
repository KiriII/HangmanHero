using System;
using UnityEditor;
using Src.HangmanCoreGameplay;
using Src.HangmanGameResult;
using UnityEngine;

public class CoreGameplayEditorWindow : EditorWindow
{
    private string _word;
    private string _symbol;

    private static HangmanGameCore _hangmanGameCore;
    private static IHangmanGamesStatistic _hangmanGamesStatistic;
    
    [MenuItem("HangmanHero/CoreTest")]
    public static void ShowWindow()
    {
        GetWindow<CoreGameplayEditorWindow>("Core Gameplay Test");
    }
    
    private void OnGUI()
    {
        if (GUILayout.Button("RESET"))
        {
            _hangmanGameCore = new HangmanGameCore(_word);

            _hangmanGamesStatistic = new HangmanGamesStatistic(_hangmanGameCore);
        }
        
        _word = EditorGUILayout.TextField("word", _word);

        if (GUILayout.Button("START GAME"))
        {
            _hangmanGameCore = new HangmanGameCore(_word);

            _hangmanGameCore.PrintModelState();
            
            _hangmanGamesStatistic.StartNewGame();
        }
        
        if (GUILayout.Button("MAKE TURN"))
        {
            _hangmanGameCore.Turn(_symbol[0]);
            
            _hangmanGameCore.PrintModelState();
            Debug.Log($"wins = {_hangmanGamesStatistic.GetWinsCount()} loses = {_hangmanGamesStatistic.GetLosesCount()}");
        }

        _symbol = EditorGUILayout.TextField("input char", _symbol);
    }
}
