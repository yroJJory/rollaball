using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DialogTester))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        DialogTester myScript = (DialogTester)target;
        
        for (int i = 0; i<10; i++) {
			if(GUILayout.Button("Play Line " + (i+1)))
			{
				myScript.PlayDialog(i);
			}
		}
    }
}