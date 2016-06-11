using UnityEngine;
using System.Collections;

public class GridMap : MonoBehaviour {

	public int gridSizeX;
	public int gridSizeZ;

	private static int[,] gridMap;
	private static GameObject[] idChart;

	// Keep GridManager throughout all stages
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Set initial grid values
	void Start () {

		gridMap = new int[gridSizeX, gridSizeZ];
		for (int x = 0; x < gridSizeX; x++) {
			for (int z = 0; z < gridSizeZ; z++) {
				gridMap [x, z] = 0;
			}
		}

		idChart = new GameObject[3] {(GameObject) (Resources.Load ("Empty Grid Tile")), (GameObject) (Resources.Load ("Stone Floor Tile")), (GameObject) (Resources.Load ("Lava Tile"))};

	}

	void Update () {
		/*if (Input.GetKeyDown ("space")) {
			logMap ();
		}*/
	}

	// Get a tile at a position
	public int getTile (int x, int z) {
		return gridMap [x, z];
	}

	// Set a tile at a position
	public void setTile (int x, int z, int id) {
		gridMap [x, z] = id;
	}

	public GameObject getObjectFromID (int id) {
		return idChart [id];
	}

	public GameObject[] getIDChart () {
		return idChart;
	}

	// Print the grid to the debug console
	private void logMap () {
		for (int x = 0; x < gridSizeX; x++) {
			for (int z = 0; z < gridSizeZ; z++) {
				Debug.Log (gridMap[x, z]);
			}
		}
	}

}
