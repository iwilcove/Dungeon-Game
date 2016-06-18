using UnityEngine;
using System.Collections;

public class GridCreator : MonoBehaviour {

	public GameObject tile;

	// Create grid
	void Start () {
		for (int x = -7; x <= 7; x++) {
			for (int z = -7; z <= 7; z++) {
				Instantiate (tile, new Vector3 (x, 0.2f, z), Quaternion.identity);
			}
		}
	}

	public void BuildGrid () {
		for (int x = -7; x <= 7; x++) {
			for (int z = -7; z <= 7; z++) {
				//GameObject go = GameObject.Find("GridManager");
				GameObject go = gameObject;
				GridMap gm = (GridMap) go.GetComponent(typeof(GridMap));
				GameObject[] ids = gm.getIDChart ();
				//Debug.Log (ids[0]);
				Instantiate (gm.getObjectFromID (gm.getTile (x + 7, z + 7)), new Vector3 (x, 0.1f, z), Quaternion.identity);
				//Debug.Log (gm.getObjectFromID (gm.getTile (x + 7, z + 7)));
			}
		}
	}
		
}
