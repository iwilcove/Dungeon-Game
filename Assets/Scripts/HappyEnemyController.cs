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
		
		Transform target = pc.getPosition();
		float step = speed * Time.deltaTime;

		Vector3 posDifference = target.position - transform.position;
		rb.AddForce (posDifference * speed);

		if (rb.velocity.magnitude > 2.0f) {
			rb.AddForce (-1 * posDifference * speed);
		}

	}

}
