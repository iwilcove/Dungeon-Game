using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float moveSpeed;
	public float scrollSpeed;
	public int sensitivity;

	private bool up;
	private bool down;
	private bool left;
	private bool right;
	private Vector3 lastMousePos = Input.mousePosition;
	private float trueMoveSpeed;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

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

		//Rotation
		if (Input.GetMouseButton (1)) {
			rotationX += Input.GetAxis ("Mouse X") * sensitivity;
			rotationY += Input.GetAxis ("Mouse Y") * sensitivity;
			Camera.main.transform.eulerAngles = new Vector3 (rotationY, rotationX, 0.0f);
		}

	}

	void FixedUpdate () {

		Debug.Log (trueMoveSpeed);

		if (Input.GetKey (KeyCode.LeftShift)) {
			trueMoveSpeed = moveSpeed * 2;
		} else {
			trueMoveSpeed = moveSpeed;
		}

		// Act on key states (movement)
		if (up) {
			transform.Translate (new Vector3 (0.0f, 0.0f, trueMoveSpeed));
		}
		if (down) {
			transform.Translate (new Vector3 (0.0f, 0.0f, -1 * trueMoveSpeed));
		}
		if (left) {
			transform.Translate (new Vector3 (-1 * trueMoveSpeed, 0.0f, 0.0f));
		}
		if (right) {
			transform.Translate (new Vector3 (trueMoveSpeed, 0.0f, 0.0f));
		}

	}

	public void changeScene (int id) {
		GameObject gameFlow = GameObject.Find("GameFlow");
		GameFlowManager gf = (GameFlowManager) gameFlow.GetComponent(typeof(GameFlowManager));
		gf.loadScene (id);
	}

}
