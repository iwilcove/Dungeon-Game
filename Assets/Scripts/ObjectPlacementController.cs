using UnityEngine;
using System.Collections;

public class ObjectPlacementController : MonoBehaviour {
	
	private GameObject selectedObj = null;
	private bool falseClickDown = false;

	public GameObject plane;

	void Update () {
		RaycastHit hit;
		if (selectedObj != null) {
			Ray objectRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (objectRay, out hit)) {
				if (hit.transform.gameObject == plane) {
					if (!falseClickDown && Input.GetMouseButtonDown (0)) {
						selectedObj = null;
					}
					if (falseClickDown && Input.GetMouseButtonUp (0)) {
						PickUpObject (selectedObj);
					}
					selectedObj.transform.position = hit.point;
				}
				Debug.DrawLine (Camera.main.transform.position, hit.point, Color.red);
			}
		}
	}

	public void PickUpObject (GameObject obj) {
		falseClickDown = true;
		selectedObj = Instantiate (obj, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
	}

}