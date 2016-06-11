using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float moveSpeed;
	public float scrollSpeed;

	private bool up;
	private bool down;
	private bool left;
	private bool right;

	void Start () {
	
	}

	void Update () {

		// Look for key down (movement)
		if (Input.GetKeyDown ("up")) {
			up = true;
		}
		if (Input.GetKeyDown ("down")) {
			down = true;
		}
		if (Input.GetKeyDown ("left")) {
			left = true;
		}
		if (Input.GetKeyDown ("right")) {
			right = true;
		}

		// Look for key up (movement)
		if (Input.GetKeyUp ("up")) {
			up = false;
		}
		if (Input.GetKeyUp ("down")) {
			down = false;
		}
		if (Input.GetKeyUp ("left")) {
			left = false;
		}
		if (Input.GetKeyUp ("right")) {
			right = false;
		}
			
		// Zoom
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.position = new Vector3(transform.position.x+scroll*scrollSpeed, transform.position.y+scroll*scrollSpeed, transform.position.z-scroll*scrollSpeed);

	}

	void FixedUpdate () {

		// Act on key states (movement)
		if (up) {
			transform.position = new Vector3(transform.position.x-moveSpeed, transform.position.y, transform.position.z+moveSpeed);
		}
		if (down) {
			transform.position = new Vector3(transform.position.x+moveSpeed, transform.position.y, transform.position.z-moveSpeed);
		}
		if (left) {
			transform.position = new Vector3(transform.position.x-moveSpeed, transform.position.y, transform.position.z-moveSpeed);
		}
		if (right) {
			transform.position = new Vector3(transform.position.x+moveSpeed, transform.position.y, transform.position.z+moveSpeed);
		}

	}

}
