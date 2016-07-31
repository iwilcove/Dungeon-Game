using UnityEngine;
using System.Collections;

public class GridCreator : MonoBehaviour {

	public GameObject tile;

	public void BuildGrid () {
		Debug.Log("BuildGrid");
		for (int x = -7; x <= 7; x++) {
			for (int z = -7; z <= 7; z++) {
				GameObject go = gameObject;
				GridMap gm = (GridMap) go.GetComponent(typeof(GridMap));
				GameObject[] ids = gm.getIDChart ();
				Instantiate (gm.getObjectFromID (gm.getTile (x + 7, z + 7)), new Vector3 (x, 0.1f, z), Quaternion.identity);
			}
		}
	}
		
}
