# rollaball
Implementation of Unity tutorial game with Fabric code wired up how I like it.

## Description

This is a very simple game. The game itself comes from [a tutorial](http://unity3d.com/learn/tutorials/projects/roll-a-ball) on the Unity website.

This example demonstrates how to setup Fabric audio middleware in Unity so that a project is ready to use it in any of its scenes. Fabric is NOT free software. It can be obtained at [Tazman Audio's website](http://www.tazman-audio.co.uk/#!fabric/c1oba "Fabric")

## A bit of helpful info

For reference, the way this works is the FabricManager and Fabric EventManager are created within a scene called "Audio". That scene is loaded when the game starts, as GameManager.cs calls its `Awake()` function. A neverending music loop begins once Fabric exists and is called from the `Update()` function, also in the GameManager.cs script. A sound event can be triggered by calling `AudioManager.PlaySound("eventName", gameObject)`, where "eventName" is the audio event you'd like to trigger and gameObject is where you'd like the event to originate.

Why would you want to setup Fabric in this manner? Because it puts audio configuration into a scene that only the sound implementer will need to modify, making it less likely that the effort made by the sound implementer will be overwritten by other project contributors. It also sets up a centralized EventManager that can be loaded into any scene at runtime. Lastly, a test environment can be built within the Audio scene and enabled when needed, which makes mixing far less work.

## Fabric Timeline

To setup the ball rolling sound, I have used a Fabric Timeline Component with a listener called `FX/Ball-Roll`. `FX/Ball-Roll` is started when `PlayerController` is initialized. The ball object's velocity is summed and used to set a Velocity parameter setup in the Timeline component. The Velocity parameter is set to control the volume of the sound, so as Velocity gets higher, the volume increases. The parameter is updated in `PlayerController.FixedUpdate()`. You can see this in Window -> Fabric -> Timeline when you have the Ball-Roll gameobject selected in the hierarchy.

## Dialog and localization

This version includes a demonstration of how to setup a dialog component and two sample languages. As the player picks up blocks, the count will be spoken in the language selected in the FabricManager. You can change the language during runtime to switch between the English and Norwegian sets.

## Project notes

This was last built using [Unity 5.2.2f1](http://unity3d.com/get-unity/download/archive "Unity Downloads") and includes Fabric 2.2.4. If you want to use this with Unity 4.x or Unity 5.0.x, a different build of Fabric needs to be obtained from the [Tazman Audio website](http://tazman-audio.co.uk/#!downloads/c16et "Fabric Downloads"). There are branches with older versions of this project for Unity 5.0.2 and 4.6.4, but the master branch will always have the most updated code.
