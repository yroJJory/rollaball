using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

	// public variable on the script, just to demonstrate 
	// that you can set the voice lines as variables.
	public string dialogFilename = "";

	void OnTriggerEnter () {
		// There are three vitally important parts that have to be setup.
		// 1. You must put the dialog inside /Assets/Resources
		// 2. You must setup the languages and paths for them in Window -> Fabric -> Lanuguages
		// 3. You must configure the default language in the FabricManager.
		//    -- You can change the language setting during runtime to switch languages manually!

		// just for testing purposes, let's see what language we are set to
		string languageName = Fabric.FabricManager.Instance.GetLanguageName();
		Debug.Log("Our language is set to " + languageName + ".");

		// Set the current line of dialog.
		// You would do this each time you load a new line to be played.
		AudioManager.SetDialogLine(dialogFilename, "DX/Dialog");

		// Trigger the dialog to play.
		AudioManager.PlaySound("DX/Dialog");
	}
	
}
