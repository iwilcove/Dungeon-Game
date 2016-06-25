using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start() {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate() {
		transform.position = player.transform.position + offset;
	}

	public void changeScene (int id) {
		GameObject gameFlow = GameObject.Find("GameFlow");
		GameFlowManager gf = (GameFlowManager) gameFlow.GetComponent(typeof(GameFlowManager));
		gf.loadScene (id);
	}

}

