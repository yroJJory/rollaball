using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DialogTester))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}