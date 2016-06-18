using UnityEngine;
using System.Collections;

public class GameFlowManager : MonoBehaviour {

	public static GameFlowManager instance = null;

	public static bool builtGrid = true;

	void Awake() {

		// Keep GameFlow throughout all stages
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
		
	void Update () {

		//when this is added it works, but when it's gone it doesn't -- C# why u do this.
		if (builtGrid = false)
			//Debug.Log (builtGrid);

		// Check for next scene indicator
		if (Input.GetKeyDown ("t")) {
			dungeonPlayerScene ();
		}

		if (Application.loadedLevel == 1 && !builtGrid) {
			builtGrid = true;
			GameObject go = GameObject.Find("GridManager");
			GridCreator gc = (GridCreator) go.GetComponent(typeof(GridCreator));
			gc.BuildGrid ();
			Debug.Log (builtGrid);
		}

		if (Application.loadedLevel == 2 && !builtGrid) {
			builtGrid = true;
			GameObject go = GameObject.Find("GridManager");
			GridCreator gc = (GridCreator) go.GetComponent(typeof(GridCreator));
			gc.BuildGrid ();
			Debug.Log (builtGrid);
		}

	}

	public void dungeonPlayerScene () {
		Application.LoadLevel (1);
		builtGrid = false;
	}

	public void dungeonEditorScene () {
		Application.LoadLevel (2);
		builtGrid = false;
	}

	public void loadScene (int id) {
		Application.LoadLevel (id);
		builtGrid = false;
	}

	public void setBuiltGrid (bool val) {
		builtGrid = val;
	}

}
