using UnityEngine;
using System.Collections;

public class algaeLifespan3 : MonoBehaviour {

	Object babyAlgaePrefab;
	Object mediAlgaePrefab;
	Object flowerAlgaePrefab;
	Object deadAlgaePrefab;

	GameObject algaeGothamDeserves;

	float lifeTimer;
	float eatingTimer = 0f;

	string algaeStatus = "none";

	Vector3 planetCenter = new Vector3(0,0,0);


	// Use this for initialization
	void Start () {
		lifeTimer = Random.Range(7.0f, 12.0f);

		babyAlgaePrefab = Resources.Load("prefabs/babyAlgaePrefab");
		mediAlgaePrefab = Resources.Load("prefabs/mediAlgaePrefab");
		flowerAlgaePrefab = Resources.Load("prefabs/flowerAlgaePrefab");
		deadAlgaePrefab = Resources.Load("prefabs/deadAlgaePrefab");
	
		algaeGothamDeserves = (GameObject)Instantiate(babyAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position - planetCenter));
		algaeGothamDeserves.transform.parent = gameObject.transform;
		algaeStatus = "baby";
	}
	
	// Update is called once per frame
	void Update () {

		if (lifeTimer < 12.01 && algaeStatus != "dead") {
			lifeTimer -= Time.deltaTime;
			//Debug.Log (lifeTimer);
		}

		if (lifeTimer > 12) {
			Destroy (algaeGothamDeserves);
			Debug.Log ("It died bc you are bad news");
		} else if (lifeTimer < 12 && lifeTimer > 8 && algaeStatus != "baby") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(babyAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position - planetCenter));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "baby";
		} else if (lifeTimer < 8 && lifeTimer > 4 && algaeStatus != "medi") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(mediAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position - planetCenter));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "medi";
		} else if (lifeTimer < 4 && lifeTimer > 0 && algaeStatus != "flower") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(flowerAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position - planetCenter));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "flower";
		} else if (lifeTimer < 0 && algaeStatus != "dead") {
			Destroy (algaeGothamDeserves);
			algaeGothamDeserves = (GameObject)Instantiate(deadAlgaePrefab, transform.position, Quaternion.LookRotation(transform.position - planetCenter));
			algaeGothamDeserves.transform.parent = gameObject.transform;
			algaeStatus = "dead";
			Debug.Log ("It died bc you are neglectful");
		}
	}

	void OnTriggerStay(Collider other) {

		if (other.gameObject.name == "LeafSheep") {
			Debug.Log ("Still colliding with leaf sheep");
			if (algaeStatus != "dead") {
				eatingTimer += Time.deltaTime;
				if (eatingTimer > 1) {
					lifeTimer += 4;
					eatingTimer = 0;
				}
			}
		}
	}

}
