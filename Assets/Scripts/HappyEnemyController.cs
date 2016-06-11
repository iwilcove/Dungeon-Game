using UnityEngine;
using System.Collections;

public class HappyEnemyController : MonoBehaviour {

	public float speed;

	private GameObject player;
	private PlayerController pc;
	private Rigidbody rb;

	void Start() {

		rb = GetComponent<Rigidbody>();

		player = GameObject.Find("Player");
		pc = (PlayerController) player.GetComponent(typeof(PlayerController));

	}

	void Update() {

		// Calculate move distance
		Transform target = pc.getPosition();
		float step = speed * Time.deltaTime;

		// Put move distance into effect
		Vector3 posDifference = target.position - transform.position;
		rb.AddForce (posDifference * speed);

		// If the magnitude of velocity is over 2, it gets lowered
		if (rb.velocity.magnitude > 2.0f) {
			rb.AddForce (-1 * posDifference * speed);
		}

	}

}
