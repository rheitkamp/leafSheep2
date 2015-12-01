using UnityEngine;
using System.Collections;

public class gravityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		/*
		Vector3 gravityOrigin = new Vector3 (0f, 0f, 0f);

		Vector3 toGravityOriginFromObject = gravityOrigin - gameObject.transform.position;
		toGravityOriginFromObject.Normalize ();

		float accelerationDueToGravity = 9.8f;
		toGravityOriginFromObject *= accelerationDueToGravity * gameObject.GetComponent<Rigidbody>().mass * Time.deltaTime;

		gameObject.GetComponent<Rigidbody>().AddForce (toGravityOriginFromObject, ForceMode.Acceleration);
		*/
	}
}
