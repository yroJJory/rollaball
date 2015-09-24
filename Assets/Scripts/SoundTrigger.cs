using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {
	public string eventName;
	public GameObject theParentGameObject;

	private GameObject thePlayer;
	void OnTriggerEnter() {
		if (AudioManager.FabricLoaded) {
			AudioManager.PlaySound(eventName, theParentGameObject);
		}
	}
}
