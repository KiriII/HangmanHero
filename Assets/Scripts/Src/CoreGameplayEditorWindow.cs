using System;
using UnityEditor;
using Src.HangmanCoreGameplay;
using UnityEngine;

public class CoreGameplayEditorWindow : EditorWindow
{
    private string _word;
    private string _symbol;

    private static HangmanGameCore _hangmanGameCore;
    
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

            _hangmanGameCore.PrintModelState();
        }
        
        _word = EditorGUILayout.TextField("word", _word);

        if (GUILayout.Button("MAKE TURN"))
        {
            _hangmanGameCore.Turn(_symbol[0]);
            
            _hangmanGameCore.PrintModelState();
        }
        
        _symbol = EditorGUILayout.TextField("input char", _symbol);
    }
}
