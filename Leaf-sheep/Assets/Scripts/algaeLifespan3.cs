using UnityEngine;
using System.Collections;

public class algaeLifespan3 : MonoBehaviour {
	// Declare public variables
	float lifeTimer = 0f;

	//Declare private variables
	bool youreDone = false;

	float eatingTimer = 0f;
	float lifeTimerMax = 30f;

	string algaeStatus = "none";
	
	Vector3 currentPos;

	Object babyAlgaePrefab;
	Object mediAlgaePrefab;
	Object flowerAlgaePrefab;
	Object deadAlgaePrefab;

	GameObject algaeGothamDeserves;
	GameObject DEADalgaeGothamDeserves;
	GameObject progressBar;
	GameObject progressBarBackground;
	GameObject progressMeter;
	GameObject nextLevelButton;

	RectTransform progressBarRect;
	RectTransform progressBarMaxRect;

	void Start () {

		// Set the starting value of the timer to a random number
		lifeTimer = Random.Range(9.0f, 30f);	

		// Load objects from Resources directory
		babyAlgaePrefab = Resources.Load("prefabs/babyAlgaeBlendPre1");
		mediAlgaePrefab = Resources.Load("prefabs/mediAlgaeBlendPre4");
		flowerAlgaePrefab = Resources.Load("prefabs/flowerAlgaeBlendPre");
		deadAlgaePrefab = Resources.Load("prefabs/deadAlgaeBlendPre");

		// Get references to objects in scene
		progressBar = GameObject.Find ("ProgressBar");
		progressBarBackground = GameObject.Find ("ProgressBarBackground");
		progressMeter = GameObject.Find ("ProgressMeter");
		nextLevelButton = GameObject.Find ("nextLevel");
		progressBarRect = progressBar.GetComponent<RectTransform>();
		progressBarMaxRect = progressBarBackground.GetComponent<RectTransform> ();

		// Instantiate a baby algae body for the algae
		algaeGothamDeserves = (GameObject)Instantiate(babyAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position));
		algaeGothamDeserves.transform.parent = gameObject.transform;
		algaeStatus = "baby";

		// Make the Next Level button invisible at the start of the scene
		//nextLevelButton.SetActive (false);

		//Debug.Log ("Next level should be invisible now");

	}

	void Update () {

		// Decrement algae timer while the algae is alive
		if (lifeTimer <= 30.1 && algaeStatus != "dead") {
			lifeTimer -= Time.deltaTime;
			Debug.Log (lifeTimer);
		}

		// Change the model of the algae depending on the algae age
		if (lifeTimer > 30) {
			Destroy (algaeGothamDeserves);
			Debug.Log ("It died bc you are bad news");
		} else if (lifeTimer < 30 && lifeTimer > 20 && algaeStatus != "baby") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(babyAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "baby";
		} else if (lifeTimer < 20 && lifeTimer > 10 && algaeStatus != "medi") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(mediAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "medi";
		} else if (lifeTimer < 10 && lifeTimer > 0 && algaeStatus != "flower") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(flowerAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "flower";
		} else if (lifeTimer < 0 && algaeStatus != "dead") {
			Destroy (algaeGothamDeserves);
			DEADalgaeGothamDeserves = (GameObject)Instantiate(deadAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position));
			DEADalgaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "dead";
			Debug.Log ("It died bc you are neglectful");
		}

		// When the progress bar gets to the maximum width
		if (progressBarRect.localScale.x >= progressBarMaxRect.localScale.x && youreDone == false) {
			youreDone = true;

			// Turn the progress meter off and the next level button on
			progressMeter.SetActive (false);

			// Get leaf sheep's mover and make it stop
			GameObject leafSheep = GameObject.Find ("LeafSheep");
			leafSheep.GetComponent<moveLeafsheep>().enabled = false;

			leafSheep.GetComponent<gameManager>();
			//Debug.Log ("Winner!!!");

		}

		// if all the algaes are dead, turn on tryAgain

	}

	void OnTriggerStay(Collider other) {

		if (other.gameObject.name == "LeafSheep") {
			//Debug.Log ("Still colliding with leaf sheep");

			// When colliding with the flower algae, eat it
			if (algaeStatus == "flower" /*&& youreDone == false*/) {
				EatFloweringAlgae();
			}

			// When colliding with other life stages, add to the life timer
			if (algaeStatus != "dead") {
				eatingTimer += Time.deltaTime;
				if (eatingTimer > 1) {
					lifeTimer += 4;
					eatingTimer = 0;
				}
			}
		}
	}

	// Eat the flowering algae
	void EatFloweringAlgae() {
		if (progressBarRect.localScale.x < progressBarMaxRect.localScale.x) {
			progressBarRect.localScale += new Vector3 (0.5f, 0f, 0f);
			Debug.Log ("Eating Flowers!");
		}


	}

}
