using UnityEngine;
using System.Collections;

public class GameFlowManager : MonoBehaviour {

	private bool builtGrid;

	void Awake() {

		// Keep GameFlow throughout all stages
		DontDestroyOnLoad(transform.gameObject);

	}
		
	void Update () {
		
		// Check for next scene indicator
		if (Input.GetKeyDown ("t")) {
			dungeonPlayerScene ();
		}
		if (Application.loadedLevel == 1 && !builtGrid) {
			GameObject go = GameObject.Find("GridManager");
			GridCreator gc = (GridCreator) go.GetComponent(typeof(GridCreator));
			gc.BuildGrid ();
			builtGrid = true;
		}
			
	}

	public void dungeonPlayerScene() {
		Application.LoadLevel (1);
	}

	public void dungeonEditorScene() {
		Application.LoadLevel (0);
	}

}
