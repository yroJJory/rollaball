using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	
	void Start() {
		var countText = GetComponent("countText") as Text;
		var winText = GetComponent("winText") as Text;
		count = 0;
//		winText.text = "";
		SetCountText();
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
		// if the ball is moving in *any* direction, totalVel would *have* to be more than 0.
		var totalVel = vel.x + vel.y + vel.z;
		if (totalVel > 0.0) {
			// send to the velocity parameter which controls our sound's volume
			Fabric.EventManager.Instance.SetParameter("FX/Ball-Roll", "Velocity", totalVel, gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			AudioManager.PlaySound("FX/Pickup-Item", other.gameObject);
			other.gameObject.SetActive(false);
			count++;
			
			SetCountText();
			
			if (count >= 12) {
				winText.text = "YOU WIN!";
				AudioManager.PlaySound("FX/Game-End", other.gameObject);
			}
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
	}	
}
