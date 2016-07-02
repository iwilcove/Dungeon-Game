using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {

	public float darkness;
	public GameObject placeTile;
	public float height;
	public int id;

	private Renderer rend;
	private bool touchingMe;  

	void Start() {
		rend = GetComponent<Renderer>();
		touchingMe = false;
	}

	// Hover highlighting
	void OnMouseEnter() {
		if (Application.loadedLevel == 2) {
			rend.material.color = Color.grey;
			touchingMe = true;
		}
	}
	void OnMouseOver() {
		if (Application.loadedLevel == 2) {
			rend.material.color = new Color (darkness, darkness, darkness);
			touchingMe = true;
		}
	}
	void OnMouseExit() {
		if (Application.loadedLevel == 2) {
			rend.material.color = Color.white;
			touchingMe = false;
		}
	}

	void Update () {

		// Place tile
		if (Application.loadedLevel == 2) {
			//Debug.Log (touchingMe);
			if (Input.GetMouseButtonDown (0) && touchingMe) {
				GameObject go = GameObject.Find ("GridManager");
				GridMap gm = (GridMap)go.GetComponent (typeof(GridMap));
				TileManager tm = (TileManager)placeTile.GetComponent (typeof(TileManager));

				gm.setTile ((int)(transform.position.x) + 7, (int)(transform.position.z) + 7, tm.id);
				//Debug.Log (gm.getTile ((int)(transform.position.x) + 7, (int)(transform.position.z) + 7));

				Instantiate (placeTile, new Vector3 (transform.position.x, height, transform.position.z), Quaternion.identity);
				Destroy (gameObject);

			}
		}

	}

}
