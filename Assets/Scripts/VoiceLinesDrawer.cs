using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(VoiceLines))]
public class VoiceLinesDrawer : PropertyDrawer {
	GameObject go = GameObject.Find("Voice Tester");

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

		// Get access to the script where our dialog playing function resides
		DialogTester playerScript = (DialogTester) go.GetComponent(typeof(DialogTester));

		EditorGUILayout.BeginHorizontal();
		EditorGUI.indentLevel = 1;
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);
		contentPosition.width = 100f;
		var myLine = property.FindPropertyRelative("line");
		EditorGUI.PropertyField(contentPosition, myLine, GUIContent.none);

		// create a Play button and set it up to play the dialog line entered into the corresponding field
		if (GUILayout.Button("Play", GUILayout.Width(50), GUILayout.Height(20))) {
			playerScript.PlayDialog(myLine.stringValue);
		}

		EditorGUILayout.EndHorizontal();
		EditorGUI.EndProperty();
	}
}