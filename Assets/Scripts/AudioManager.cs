using UnityEngine;
using System.Collections;

public static class AudioManager
{

	private static void playAudio(string eventName)
	{
		//AUDIO: without position
		Fabric.EventManager.Instance.PostEvent(eventName);
	}

	private static void playAudioWithPosition(string eventName, GameObject ob)
	{
		//AUDIO: with position
		Fabric.EventManager.Instance.PostEvent(eventName, ob);
	}

	public static bool FabricLoaded {get { return Fabric.EventManager.Instance; }}


	public static void PlaySound(string n)
	{
		LoadFabric();
		if (FabricLoaded)
			playAudio(n);
	}

	public static void PlaySound(string n, GameObject ob)
	{
		LoadFabric();
		if (FabricLoaded)
			playAudioWithPosition(n, ob);
	}

	public static void StopSound(string n)
	{
		Fabric.EventManager.Instance.PostEvent(n, Fabric.EventAction.StopAll);
	}

	public static void StopAllSounds(string n)
	{
		Fabric.EventManager.Instance.PostEvent(n, Fabric.EventAction.StopAll);
	}

	public static void FadeOutMusic(string n) {
		// fade out the music!
		Fabric.Component component = Fabric.FabricManager.Instance.GetComponentByName(n);
		if (component != null) {
			component.FadeOut(0.1f, 0.5f);
		}
    }

	public static void SetDialogLine(string dialogEvent, string componentName)
	{
		Fabric.EventManager.Instance.PostEvent(componentName, Fabric.EventAction.SetAudioClipReference, dialogEvent);
	}

	public static bool PauseSound(string n) {
		Fabric.EventManager.Instance.PostEvent(n, Fabric.EventAction.PauseSound);
		return true;
	}

	public static bool UnpauseSound(string n) {
		Fabric.EventManager.Instance.PostEvent(n, Fabric.EventAction.UnpauseSound);
		return true;
	}

	public static void LoadFabric()
	{
		if (FabricLoaded) { // || Application.isLoadingLevel) {
			return;
		}
		Application.LoadLevelAdditive("Audio");
	}
}
