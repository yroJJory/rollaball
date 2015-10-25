using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	
	void Start() {
		// get the screen text components
		Text countText = GetComponent("countText") as Text;
		Text winText = GetComponent("winText") as Text;

		// initialize the count of boxes that have been picked up
		count = 0;
		SetCountText();

		// Start the ball-rolling sound, which will not be audible
		// until the velocity has changed and been detected in FixedUpdate()
		AudioManager.PlaySound("FX/Ball-Roll", this.transform.gameObject);
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
		var vel = GetComponent<Rigidbody>().velocity;

		// make sure these values are all positive,
		// since we don't care about direction, only movement
		vel.x = Mathf.Abs(vel.x);
		vel.y = Mathf.Abs(vel.y);
		vel.z = Mathf.Abs(vel.z);

		// a simple hack to see if the ball is moving
		// if the ball is moving in *any* direction, 
		// totalVel would *have* to be more than 0.
		var totalVel = vel.x + vel.y + vel.z;
		if (totalVel > 0.0) {
			// send to the velocity parameter which controls our sound's volume
			Fabric.EventManager.Instance.SetParameter("FX/Ball-Roll", "Velocity", totalVel, gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		// if we collided with a pickup cube
		if (other.gameObject.tag == "PickUp") {
			// play the pickup sound
			AudioManager.PlaySound("FX/Pickup-Item", other.gameObject);

			// hide the picked up item
			other.gameObject.SetActive(false);

			// increment the count
			count++;

			// update the screen text
			SetCountText();	
		
			// set and trigger the dialog
			PlayPickupNumberDX();

			// if we reach 12, the game is over
			if (count >= 12) {
				// update the text to indicate game over state
				winText.text = "YOU WIN!";

				// Play the game end sound
				AudioManager.PlaySound("FX/Game-End", other.gameObject);
			}
		}
	}

	// Update the text on screen 
	// with the current count of picked up blocks
	void SetCountText() {
		countText.text = "Count: " + count.ToString();
	}
	
	// Play a voice file using the number of picked up blocks
	void PlayPickupNumberDX () {
		// There are three vitally important parts that have to be setup.
		// 1. You must put the dialog inside /Assets/Resources
		// 2. You must setup the languages and paths for them in Window -> Fabric -> Lanuguages
		// 3. You must configure the default language in the FabricManager.
		//    -- You can change the language setting during runtime to switch languages manually!

		// just for testing purposes, let's see what language we are set to
		string languageName = Fabric.FabricManager.Instance.GetLanguageName();
		Debug.Log("Our language is set to " + languageName + ".");

		// Set the current line of dialog.
		// You would do this each time you load a new line to be played.
		string fileNumber = count.ToString("00");
		AudioManager.SetDialogLine(("numbers_" + (fileNumber)), "DX/Dialog");

		// Trigger the dialog to play.
		AudioManager.PlaySound("DX/Dialog", this.transform.gameObject);
	}
}
