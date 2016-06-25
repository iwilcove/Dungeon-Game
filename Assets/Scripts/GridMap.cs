using UnityEngine;
using System.Collections;

public class GridMap : MonoBehaviour {

	public int gridSizeX;
	public int gridSizeZ;
	public static GridMap instance = null;

	private static int[,] gridMap;
	private static GameObject[] idChart;


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

		gridMap = new int[gridSizeX, gridSizeZ];
		for (int x = 0; x < gridSizeX; x++) {
			for (int z = 0; z < gridSizeZ; z++) {
				gridMap [x, z] = 0;
			}
		}

		idChart = new GameObject[3] {(GameObject) (Resources.Load ("Empty Grid Tile")), (GameObject) (Resources.Load ("Stone Floor Tile")), (GameObject) (Resources.Load ("Lava Tile"))};

	}

	void Update () {
		
		if (Input.GetKeyDown ("space")) {
			logMap ();
		}

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
