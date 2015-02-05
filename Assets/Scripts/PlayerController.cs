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
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce(movement * speed * Time.deltaTime);
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
