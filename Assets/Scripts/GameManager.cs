using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool mainMusicPlaying = false;

	#region Audio Events

	// Setup a section in the Inspector where
	// our sound events can be displayed/customized
	[Header("Audio Events")]

	public string MX_MainLoop = "MX/Main_Loop";

	#endregion

	void Awake () {
		// Load the Fabric manager by loading up the Audio scene!
		AudioManager.LoadFabric();
	}

	void Update () {
		if (!mainMusicPlaying) {
			if (AudioManager.FabricLoaded) {
				mainMusicPlaying = true;
				AudioManager.PlaySound(MX_MainLoop);
			}
		}
	}
}
