using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool mainMusicPlaying = false;
	private bool isGamePaused = false;

	#region Audio Events

	// Setup a section in the Inspector where
	// our sound events can be displayed/customized
	[Header("Audio Events")]

	public string MX_MainLoop = "MX/Main_Loop";
	public string Controller_SFX = "Controller/SFX";
	public string Controller_MX = "Controller/MX";
	public string Controller_DX = "Controller/DX";
	public string Controller_Amb = "Controller/Amb";
	private GameObject pauseText;

	#endregion

	void Awake () {
		// Load the Fabric manager by loading up the Audio scene!
		AudioManager.LoadFabric();
	}

	void Start() {
		pauseText = GameObject.Find("pauseText");
	}

	void Update () {
		if (!mainMusicPlaying) {
			if (AudioManager.FabricLoaded) {
				mainMusicPlaying = true;
				AudioManager.PlaySound(MX_MainLoop);
			}
		}

	    if (Input.GetKeyDown ("escape")){
	        if (!isGamePaused) {
				PauseGame();
	        }
	        else {
	        	ResumeGame();
	        }
	    }
	}

	void PauseGame() {
		// showMenu = true;
		Time.timeScale = 0;

		// Display "Game Paused" on screen
		// so the user knows what's happening
		pauseText.GetComponent<Text>().text = "Game Paused";

		// Pause each of our root sound channels
		// It has been setup like this so you can choose
		// to mute sounds, but not music or ambiences.
		AudioManager.PauseSound(Controller_DX);
		AudioManager.PauseSound(Controller_SFX);
		AudioManager.PauseSound(Controller_MX);
		AudioManager.PauseSound(Controller_Amb);

		isGamePaused = true;
	}

	void ResumeGame() {
		// showMenu = false;
		// Time.timeScale = 1.0;
		Time.timeScale = 1.0f;

		// Remove "Game Paused" from the screen.
		pauseText.GetComponent<Text>().text = "";

		// Unpause each of our root sound channels
		AudioManager.UnpauseSound(Controller_DX);
		AudioManager.UnpauseSound(Controller_SFX);
		AudioManager.UnpauseSound(Controller_MX);
		AudioManager.UnpauseSound(Controller_Amb);

		isGamePaused = false;
	}
}
