using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Board board = (Board) target;

        if(GUILayout.Button("Generate Board")){
            board.GenerateBoard();
        }
        
    }
}