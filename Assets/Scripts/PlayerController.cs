using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	private string language = "English";
	public int CurrentLanguage = 0;
	private bool isGameOver = false;

	// setup an array where we will store the names of available languages
	private string[] availableLanguages;

#region Audio Events

	// Setup a section in the Inspector where
	// our sound events can be displayed/customized
	[Header("Audio Events")]

	public string FX_BallRoll = "FX/Ball-Roll";
	public string FX_PickupItem = "FX/Pickup-Item";
	public string FX_GameEnd = "FX/Game-End";
	public string DX_Dialog = "DX/Dialog";

#endregion

#region Standard Function

	void Start() {
		// get the screen text components
		Text countText = GetComponent("countText") as Text;
		Text winText = GetComponent("winText") as Text;

		// initialize the count of boxes that have been picked up
		count = 0;
		SetCountText();

		// Start the ball-rolling sound, which will not be audible
		// until the velocity has changed and been detected in FixedUpdate()
		AudioManager.PlaySound(FX_BallRoll, this.transform.gameObject);

		// fill our array with all the languages Fabric is setup for
		availableLanguages = AudioManager.GetFabricDXLanguageArray();
		language = availableLanguages[CurrentLanguage];
	}

	void Update() {
		string lastLanguage = language;

		// Check the game's language setting
		language = availableLanguages[CurrentLanguage];

		// if the language has changed since last time
		// update the on-screen text
		if (lastLanguage != language) {
			SetCountText();

			// if the game is over,
			// update the winning text
			if (isGameOver) {
				SetWinningText();
			}

			// update lastLanguage to match our new language
			lastLanguage = language;
		}

		// If the user hit the spacebar, rotate through all available languages
		if (Input.GetKeyDown ("space")) {
			RotateLanguage();
		}
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
			AudioManager.UpdateTimelineParameter(FX_BallRoll, "Velocity", totalVel, gameObject);
		}
	}

#endregion

#region Player Functions

	// Rotate through the available languages
	void RotateLanguage() {
		// get the total number of languages Fabric knows about
		int numLanguages = availableLanguages.Length;

		// check to see if we've hit the last language
		if ((CurrentLanguage) < (numLanguages-1)) {
			// if not, increment by one
			CurrentLanguage++;
		}
		else {
			// otherwise, reset back to the first language
			CurrentLanguage = 0;
		}

		// set Fabric to the next language
		AudioManager.SetFabricDXLanguageByIndex(CurrentLanguage);
	}

	void OnTriggerEnter(Collider other) {
		// if we collided with a pickup cube
		if (other.gameObject.tag == "PickUp") {
			// play the pickup sound
			AudioManager.PlaySound(FX_PickupItem, other.gameObject);

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
				// display the winning text
				SetWinningText();

				// set the game over state to true
				isGameOver = true;

				// Play the game end sound
				AudioManager.PlaySound(FX_GameEnd, other.gameObject);
			}
		}
	}

	// Update the text on screen
	// with the current count of picked up blocks
	void SetCountText() {

		if (language == "Norwegian") {
			countText.text = "Tell: " + count.ToString();
		}
		else {
			countText.text = "Count: " + count.ToString();
		}
	}

	// Update the text on screen
	// with the winning text
	void SetWinningText() {
		// update the text to indicate game over state
		if (language == "Norwegian") {
			winText.text = "DU VINNER!";
		}
		else {
			winText.text = "YOU WIN!";
		}
	}

	// Play a voice file using the number of picked up blocks
	void PlayPickupNumberDX () {
		// There are three vitally important parts that have to be setup.
		// 1. You must put the dialog inside /Assets/Resources
		// 2. You must setup the languages and paths for them in Window -> Fabric -> Lanuguages
		// 3. You must configure the default language in the FabricManager.
		//    -- You can change the language setting during runtime to switch languages manually!

		// Set the current line of dialog.
		// You would do this each time you load a new line to be played.
		string fileNumber = count.ToString("00");
		AudioManager.SetDialogLine(("numbers_" + (fileNumber)), DX_Dialog);

		// Trigger the dialog to play.
		AudioManager.PlaySoundNotify(DX_Dialog, this.transform.gameObject, AudioManager.Notify);
	}

#endregion
}
