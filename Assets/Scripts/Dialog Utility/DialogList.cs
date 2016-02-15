using UnityEditor;
using UnityEngine;

public static class DialogList {

	private static GUIContent
		moveButtonContent = new GUIContent("\u21b4", "move down"),
		duplicateButtonContent = new GUIContent("+", "duplicate"),
		deleteButtonContent = new GUIContent("-", "delete"),
		addButtonContent = new GUIContent("+", "add element"),
		playButtonContent = new GUIContent("Play", "Play line");

	public static void Show (SerializedProperty list) { //EditorListOption options = EditorListOption.Default
	//	bool
				//showListLabel = (options & EditorListOption.ListLabel) != 0,
				//showListSize = (options & EditorListOption.ListSize) != 0;
				bool showListLabel = false;
				bool showListSize = false;

		if (showListLabel) {
			EditorGUILayout.PropertyField(list);
			EditorGUI.indentLevel += 1;
		}
		if (!showListLabel || list.isExpanded) {
			if (showListSize) {
				EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
			}
			ShowElements(list); // options
		}
		if (showListLabel) {
			EditorGUI.indentLevel -= 1;
		}
	}

	private static void ShowElements (SerializedProperty list) { // EditorListOption options
		bool
			//showElementLabels = (options & EditorListOption.ElementLabels) != 0,
			//showButtons =  (options & EditorListOption.Buttons) != 0;
			showButtons = true,
			showElementLabels = false;

		for (int i = 0; i < list.arraySize; i++) {
			if (showButtons) {
				EditorGUILayout.BeginHorizontal();
			}
			if (showElementLabels) {
				EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
			}
			else {
				EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);
			}
			if (showButtons) {
				ShowButtons(list, i);
				EditorGUILayout.EndHorizontal();
			}
		}
		if (showButtons && list.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton)) {
			list.arraySize += 1;
		}
	}

	private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
	private static GUILayoutOption playButtonWidth = GUILayout.Width(60f);

	private static void ShowButtons (SerializedProperty list, int index) {
		GameObject go = GameObject.Find("Voice Tester");

		if (GUILayout.Button(playButtonContent, EditorStyles.miniButton, playButtonWidth)) {
			var myVar = list.GetArrayElementAtIndex(index);
			PlayDialog(myVar.stringValue, go);
		}
		if (GUILayout.Button(moveButtonContent, EditorStyles.miniButtonLeft, miniButtonWidth)) {
			list.MoveArrayElement(index, index + 1);
		}
		if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid, miniButtonWidth)) {
			list.InsertArrayElementAtIndex(index);
		}
		if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth)) {
			int oldSize = list.arraySize;
			list.DeleteArrayElementAtIndex(index);
			if (list.arraySize == oldSize) {
				list.DeleteArrayElementAtIndex(index);
			}
		}
	}

	private static bool PlayDialog(string theLine, GameObject go) {
		// Play the dialog line
		AudioManager.SetDialogLine(theLine, "DX/Dialog");

		// Trigger the dialog to play.
		AudioManager.PlaySound("DX/Dialog", go);

		return true;
	}

}
