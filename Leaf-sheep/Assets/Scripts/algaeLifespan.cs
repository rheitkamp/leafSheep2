using UnityEngine;
using System.Collections;

public class algaeLifespan : MonoBehaviour {

	Object babyAlgaePrefab;
	Object mediAlgaePrefab;
	Object flowerAlgaePrefab;
	Object deadAlgaePrefab;

	GameObject babyAlgaeIRL;
	GameObject mediAlgaeIRL;
	GameObject flowerAlgaeIRL;
	GameObject deadAlgaeIRL;

	float lifeTimer = 10f;

	// Use this for initialization
	void Start () {
		babyAlgaePrefab = Resources.Load("prefabs/babyAlgaePrefab");
		mediAlgaePrefab = Resources.Load("prefabs/mediAlgaePrefab");
		flowerAlgaePrefab = Resources.Load("prefabs/flowerAlgaePrefab");
		deadAlgaePrefab = Resources.Load("prefabs/deadAlgaePrefab");
	
		babyAlgaeIRL = (GameObject)Instantiate(babyAlgaePrefab, transform.position, Quaternion.identity);
		babyAlgaeIRL.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer -= Time.deltaTime;
		Debug.Log (lifeTimer);

		if (lifeTimer < 8 && lifeTimer > 4 && mediAlgaeIRL == null) {
			Destroy (babyAlgaeIRL);
			mediAlgaeIRL = (GameObject)Instantiate(mediAlgaePrefab, transform.position, Quaternion.identity);
			mediAlgaeIRL.transform.parent = gameObject.transform;
		}

		else if (lifeTimer < 4 && lifeTimer > 0 && flowerAlgaeIRL == null) {
			Destroy (mediAlgaeIRL);
			flowerAlgaeIRL = (GameObject)Instantiate(flowerAlgaePrefab, transform.position, Quaternion.identity);
			flowerAlgaeIRL.transform.parent = gameObject.transform;
		}

		else if (lifeTimer < 0 && deadAlgaeIRL == null) {
			Destroy (flowerAlgaeIRL);
			deadAlgaeIRL = (GameObject)Instantiate(deadAlgaePrefab, transform.position, Quaternion.identity);
			deadAlgaeIRL.transform.parent = gameObject.transform;
		}
	}

	void OnTriggerStay(Collider other) {
		Debug.Log ("Still colliding with trigger object");


	}
}
