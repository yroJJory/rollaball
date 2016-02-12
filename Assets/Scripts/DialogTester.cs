using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class DialogTester : MonoBehaviour {

	// We'll get however many VoiceLines as we'd like
	// This refers to a custom class, which just has a single string subobject
	// Then we use VoiceLinesDrawer.cs to make a custom GUI in the inspector

	[Header("Dialog Lines")]

	public VoiceLines voiceline01;
	public VoiceLines voiceline02;
	public VoiceLines voiceline03;
	public VoiceLines voiceline04;
	public VoiceLines voiceline05;
	public VoiceLines voiceline06;
	public VoiceLines voiceline07;
	public VoiceLines voiceline08;
	public VoiceLines voiceline09;
	public VoiceLines voiceline10;

    #region Audio Events

    #endregion

	public bool PlayDialog(string theLine) {
		// Play the dialog line
		AudioManager.SetDialogLine(theLine, "DX/Dialog");

		// Trigger the dialog to play.
		AudioManager.PlaySound("DX/Dialog", this.gameObject);
		
		return true;
	}
	
}
