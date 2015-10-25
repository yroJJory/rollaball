using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool mainMusicPlaying = false;

	void Awake () {
		// Load the Fabric manager by loading up the Audio scene!
		AudioManager.LoadFabric();
	}

	void Update () {
		if (!mainMusicPlaying) {
			if (AudioManager.FabricLoaded) {
				mainMusicPlaying = true;
				AudioManager.PlaySound("MX/Main_Loop");
			}
		}
	}
}
