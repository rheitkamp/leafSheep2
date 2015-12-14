using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	// Declare static variables
	static int totalLevels = 3;

	// Declare public variables
	public int currentLevel;
	public GameObject nextLevelButton;
	public GameObject winnerButton;
	public GameObject tryAgainButton;
	
	// Declare private variables
	Object alga;

	GameObject progressMeter;
	GameObject progressBar;

	RectTransform progressBarRect; 
	
	void Start () {
		// Get references to objects in scene
		nextLevelButton = GameObject.Find ("nextLevel");
		progressMeter = GameObject.Find ("ProgressMeter");
		progressBar = GameObject.Find ("ProgressBar");
		winnerButton = GameObject.Find ("winner");
		tryAgainButton = GameObject.Find ("tryAgain");

		progressBarRect = progressBar.GetComponent<RectTransform>();

		// Load the first level
		currentLevel = 1;
		LevelLoader ();

		nextLevelButton.SetActive (false);
		winnerButton.SetActive (false);
		tryAgainButton.SetActive (false);
	}

	void Update () {
		DeveloperCheat ();
	}

	// A button function that sets up the next level when the player completes the current level
	public void ButtonGoToNextLevel() {
		// Go to the next level

		if (currentLevel < 3) {
			currentLevel++;
			LevelLoader ();

		}

		// Make the next level button disappear
		nextLevelButton.SetActive (false);
	}

	public void ButtonGoToStart() {
		Application.LoadLevel ("Start");
	}

	public void PrepLevel() {
		// Clear old algae
		ClearAlgae ();

		// Show the progress bar and make it the right size [BROKEN]
		progressMeter.SetActive (true);
		Vector3 progressBarStartWidth = new Vector3 (1f, 1.5f, 1f);
		progressBarRect.localScale = progressBarStartWidth;

		// Make the leafsheep move again
		GetComponent<moveLeafsheep> ().enabled = true;

		algaeLifespan3.howManyAlgaes = 0;


	}

	// A button function that lets the player replay the level
	public void ButtonReplay() {
		//Debug.Log ("current level: " + currentLevel);
		LevelLoader ();
		tryAgainButton.SetActive (false);
	}

	// A switch to set up the right level
	public void LevelLoader () {
		PrepLevel ();
		switch (currentLevel) {
			case 1:
				InstantiateAlga();
				//Set progress holder length
				//Set progress meter length
				Debug.Log ("You're on level 1");
				break;
			case 2:
			//Set progress holder length
			//Set progress meter length
				InstantiateAlga(); //
				InstantiateAlga();
				Debug.Log ("You're on level 2");
				break; 
			case 3:
				//Set progress holder length
				//Set progress meter length
				InstantiateAlga();
				InstantiateAlga();				
				InstantiateAlga();
				Debug.Log ("You're on level 3");
				break;	
			default:
				Debug.Log ("On the start menu.");
				break;	
		}
	
	}

	public void ClearAlgae () {
		GameObject[] algaeInScene = GameObject.FindGameObjectsWithTag ("algae");

		foreach (GameObject alga in algaeInScene) {
			Destroy(alga);
		}
	}

	public void InstantiateAlga () {
		float randomX = Random.Range (-3f, 4f);
		float randomZ = Random.Range (-3.5f, 3.5f);
		float y = 0.33f;
		Vector3 algaPosition = new Vector3 (randomX, y, randomZ);
		Debug.Log (algaPosition);
		alga = Resources.Load("prefabs/Algae");
		alga = (GameObject)Instantiate(alga, algaPosition, Quaternion.identity);
	}

	public void DeveloperCheat () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			currentLevel = 1;
			LevelLoader ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			currentLevel = 2; 
			LevelLoader ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			currentLevel = 3; 
			LevelLoader ();
		}
	}


}

