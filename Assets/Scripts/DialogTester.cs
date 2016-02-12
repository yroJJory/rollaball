using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogTester : MonoBehaviour {

	private int count = 0;
	private bool waitActive = false;
	private bool isDialogPlaying = false;

    #region Audio Events

    [Header("Audio Events")]
    public string DX_Line01 = "numbers_01";
    public string DX_Line02 = "numbers_02";
    public string DX_Line03 = "numbers_03";
    public string DX_Line04 = "numbers_04";
    public string DX_Line05 = "numbers_05";
    public string DX_Line06 = "numbers_06";
    public string DX_Line07 = "numbers_07";
    public string DX_Line08 = "numbers_08";
    public string DX_Line09 = "numbers_09";
    public string DX_Line10 = "numbers_10";

	private ArrayList lineArray = new ArrayList();

    #endregion

	void Start() {
		// put the filenames into an array 
		// so we can iterate through them
		lineArray.Add(DX_Line01);
		lineArray.Add(DX_Line02);
		lineArray.Add(DX_Line03);
		lineArray.Add(DX_Line04);
		lineArray.Add(DX_Line05);
		lineArray.Add(DX_Line06);
		lineArray.Add(DX_Line07);
		lineArray.Add(DX_Line08);
		lineArray.Add(DX_Line09);
		lineArray.Add(DX_Line10);
	}

	void Update() {
		// We need to do this to make sure that if 
		// the user updates the values during runtime, 
		// we play what they entered!
		lineArray[0] = DX_Line01;
		lineArray[1] = DX_Line02;
		lineArray[2] = DX_Line03;
		lineArray[3] = DX_Line04;
		lineArray[4] = DX_Line05;
		lineArray[5] = DX_Line06;
		lineArray[6] = DX_Line07;
		lineArray[7] = DX_Line08;
		lineArray[8] = DX_Line09;
		lineArray[9] = DX_Line10;
	}

	public bool PlayDialog(int num) {
		// Play the dialog line
		AudioManager.SetDialogLine((string) lineArray[num], "DX/Dialog");

		// Trigger the dialog to play.
		AudioManager.PlaySound("DX/Dialog", this.gameObject);
		
		return true;
	}
	
}
