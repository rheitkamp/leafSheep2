using UnityEngine;
using System.Collections;

public class algaeLifespan3 : MonoBehaviour {

	Object babyAlgaePrefab;
	Object mediAlgaePrefab;
	Object flowerAlgaePrefab;
	Object deadAlgaePrefab;

	GameObject algaeGothamDeserves;
	GameObject DEADalgaeGothamDeserves;

	GameObject progressBar;
	GameObject progressBarBackground;
	RectTransform progressBarWidth;
	RectTransform progressBarMaxWidth;

	//static GameObject nextLevel;
	//static bool youreDone = false;

	float lifeTimer;
	float eatingTimer = 0f;


	string algaeStatus = "none";

	//Vector3 planetCenter = new Vector3(0,0,0);

	Vector3 currentPos;
	
	// Use this for initialization
	void Start () {
		progressBar = GameObject.Find ("ProgressBar");
		progressBarBackground = GameObject.Find ("ProgressBarBackground");
		progressBarWidth = progressBar.GetComponent<RectTransform>();
		progressBarMaxWidth = progressBarBackground.GetComponent<RectTransform> ();

		//nextLevel = GameObject.Find ("nextLevel");
		//nextLevel.SetActive (false);

		lifeTimer = Random.Range(9.0f, 30.0f);

		babyAlgaePrefab = Resources.Load("prefabs/babyAlgaeBlendPre1");
		mediAlgaePrefab = Resources.Load("prefabs/mediAlgaeBlendPre4");
		flowerAlgaePrefab = Resources.Load("prefabs/flowerAlgaeBlendPre");
		deadAlgaePrefab = Resources.Load("prefabs/deadAlgaeBlendPre");
	
		algaeGothamDeserves = (GameObject)Instantiate(babyAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position));
		algaeGothamDeserves.transform.parent = gameObject.transform;
		algaeStatus = "baby";

		//currentPos = gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (lifeTimer < 30.01 && algaeStatus != "dead") {
			lifeTimer -= Time.deltaTime;
			//Debug.Log (lifeTimer);
		}

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

		if (algaeStatus == "dead") {

			/* tell it where to be...didn't work
			DEADalgaeGothamDeserves.transform.position = currentPos;
			*/
			
			/*
			 * set translation to 0...didn't work
			Vector3 noYouMayNot = new Vector3 (0,0,0);
			DEADalgaeGothamDeserves.transform.Translate(noYouMayNot, Space.Self);
			 */
			
			/*
			 * set velocit to zero...didn't work
			 * 
			Rigidbody algaeRB;
			algaeRB = DEADalgaeGothamDeserves.GetComponent<Rigidbody>();
			algaeRB.velocity = new Vector3(0,0,0);
			Debug.Log (algaeRB.velocity);
			*/
		}

		if (progressBarWidth.localScale.x >= progressBarMaxWidth.localScale.x) {
			//youreDone = true;
			
			//get leaf sheep's mover and make it stop
			//turn on a button on the canvas that says next level
			//next level button loads next level
			
			//progressBar.SetActive (false);
			//progressBarBackground.SetActive (false);
			//nextLevel.SetActive (true);
			
			Debug.Log ("Winner!!!");
		}

		//if all the algaes are dead, turn on tryAgain

	}

	void OnTriggerStay(Collider other) {

		if (other.gameObject.name == "LeafSheep") {
			Debug.Log ("Still colliding with leaf sheep");

			if (algaeStatus == "flower" /*&& youreDone == false*/) {
				EatFloweringAlgae();
			}

			if (algaeStatus != "dead") {
				eatingTimer += Time.deltaTime;
				if (eatingTimer > 1) {
					lifeTimer += 4;
					eatingTimer = 0;
				}
			}

		}
	}

	void EatFloweringAlgae() {
		if (progressBarWidth.localScale.x < progressBarMaxWidth.localScale.x) {
			progressBarWidth.localScale += new Vector3 (0.01f, 0f, 0f);
			Debug.Log ("Eating Flowers!");
		}


	}

}
