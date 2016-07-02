using UnityEngine;
using System.Collections;

public class GameFlowManager : MonoBehaviour {

	public static GameFlowManager instance = null;

	private bool built = false;

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

	void OnLevelWasLoaded () {
		built = false;

	}

	void Update () {
		
		// Check for next scene indicator
		if (Input.GetKeyDown ("t")) {
			dungeonPlayerScene ();
		}
			
		if (Application.loadedLevel == 1 && !built) {
			GameObject go = GameObject.Find("GridManager");
			GridCreator gc = (GridCreator) go.GetComponent(typeof(GridCreator));
			gc.BuildGrid ();
			built = true;
		}
			
		if (Application.loadedLevel == 2 && !built) {
			GameObject go = GameObject.Find("GridManager");
			GridCreator gc = (GridCreator) go.GetComponent(typeof(GridCreator));
			gc.BuildGrid ();
			built = true;
		}

	}

	public void dungeonPlayerScene () {
		Application.LoadLevel (1);
	}

	public void dungeonEditorScene () {
		Application.LoadLevel (2);
	}

	public void loadScene (int id) {
		Application.LoadLevel (id);
	}

}
