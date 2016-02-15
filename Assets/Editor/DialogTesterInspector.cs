using UnityEditor;
using UnityEngine;
using System;

[Flags]
public enum EditorListOption {
	None = 0,
	ListSize = 1 << 0,
	ListLabel = 1 << 1,
	ElementLabels = 1 << 2,
	Buttons = 1 << 3,
	Default = ListSize | ListLabel | ElementLabels,
	NoElementLabels = ListSize | ListLabel,
	All = Default | Buttons
}

// this is a comment
[CustomEditor(typeof(DialogTester))]
public class DialogTesterInspector : Editor {

	public override void OnInspectorGUI () {
		serializedObject.Update();
		DialogList.Show(serializedObject.FindProperty("dx"));

		serializedObject.ApplyModifiedProperties();
	}

}
