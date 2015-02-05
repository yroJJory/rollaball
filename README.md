# rollaball
Implementation of Unity tutorial game with Fabric code wired up how I like it.

## Description

This is a very simple game. The game itself comes from [a tutorial](http://unity3d.com/learn/tutorials/projects/roll-a-ball) on the Unity website.

This example demonstrates how to setup Fabric audio middleware in Unity so that a project is ready to use it in any of its scenes. Fabric is NOT free software. It can be obtained at [Tazman Audio's website](http://www.tazman-audio.co.uk/#!fabric/c1oba "Fabric")

## A bit of helpful info

For reference, the way this works is the FabricManager and Fabric EventManager are created within a scene called "Audio". That scene is loaded when the game starts, as GameManager.cs calls its `Awake()` function. A neverending music loop begins once Fabric exists and is called from the `Update()` function, also in the GameManager.cs script. A sound event can be triggered by calling `AudioManager.PlaySound("eventName", gameObject)`, where "eventName" is the audio event you'd like to trigger and gameObject is where you'd like the event to originate.

Why would you want to setup Fabric in this manner? Because it puts audio configuration into a scene that only the sound implementer will need to modify, making it less likely that the effort made by the sound implementer will be overwritten by other project contributors. It also sets up a centralized EventManager that can be loaded into any scene at runtime. Lastly, a test environment can be built within the Audio scene and enabled when needed, which makes mixing far less work.
