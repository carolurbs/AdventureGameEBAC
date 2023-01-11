using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(FSMExample))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FSMExample fsmExample = (FSMExample)target;
        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");
        if (fsmExample.stateMachine == null) return;
        if (fsmExample.stateMachine.CurrentState !=null)
            EditorGUILayout.LabelField("Current State: ", fsmExample.stateMachine.CurrentState.ToString());
        showFoldout = EditorGUILayout.Foldout(showFoldout, "Available States");  
        if (showFoldout)
        {
            if(fsmExample.stateMachine.CurrentState != null)
            {

            var keys =fsmExample.stateMachine.dictionaryState.Keys.ToArray();
            var vals = fsmExample.stateMachine.dictionaryState.Values.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                EditorGUILayout.LabelField(string.Format("{0}::{1}", keys [i], vals[i]));  
            }
            }
        }
    }
}
