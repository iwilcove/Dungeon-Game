using UnityEngine;
using System.Collections;

public class GridMap : MonoBehaviour {

	private static GameObject[] idChart;
	private RoomData rd;

	public static GridMap instance = null;

	void Awake() {

		// Keep GridManager throughout all stages
		DontDestroyOnLoad(transform.gameObject);

		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);  
		
	}

	// Set initial grid values
	void Start () {

		rd = new RoomData (15, 15);

		idChart = new GameObject[3] {(GameObject) (Resources.Load ("Empty Grid Tile")), (GameObject) (Resources.Load ("Stone Floor Tile")), (GameObject) (Resources.Load ("Lava Tile"))};

	}

	// Get a tile at a position
	public int getTile (int x, int z) {
		return rd.getTile (x, z);
	}

	// Set a tile at a position
	public void setTile (int x, int z, int id) {
		rd.setTile (x, z, id);
	}

	public GameObject getObjectFromID (int id) {
		return idChart [id];
	}

	public GameObject[] getIDChart () {
		return idChart;
	}

}
