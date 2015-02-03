/*
fadeIn_BlendComponent = GetBlendComponentByEventListener(theMusicEvent);
if (fadeIn_BlendComponent != null)
{
	fadeIn_BlendComponent.OverrideFadeProperties = true;
	//fadeIn_BlendComponent.
	Debug.Log("Found component - " + fadeIn_BlendComponent, fadeIn_BlendComponent);

	//if(Fabric.FabricManager.Instance.FadeInComponent())
	if (!Fabric.EventManager.Instance.IsEventActive(theMusicEvent, gameObject))
	{
		fadeIn_BlendComponent.FadeOutTime = 0f;
		Fabric.EventManager.Instance.PostEvent(theMusicEvent, EventAction.SetFadeOut);
		Fabric.EventManager.Instance.PostEvent(theMusicEvent, EventAction.PlaySound, gameObject);
	}

	fadeIn_BlendComponent.FadeInTime = fadeDuration;
	fadeIn_BlendComponent.FadeInCurve = fadeInCurve;

	Fabric.EventManager.Instance.PostEvent(theMusicEvent, EventAction.SetFadeIn);
	currentEventPlaying = theMusicEvent;
}
return;
*/