using UnityEngine;
using System.Collections;

public class RotateLeafsheep : MonoBehaviour {

	public float rotationSpeed = 3f;

	Vector3 xComponent = new Vector3 (0,0,0);
	Vector3 zComponent = new Vector3 (0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// rotate leaf sheep toward opposite of direction of motion
		
		// if pressing arrow keys, set direction based on input
		if (Input.GetAxis ("Vertical") > 0) {
			xComponent = new Vector3(0,1,0);
		} else if (Input.GetAxis ("Vertical") < 0) {
			xComponent = new Vector3(0,-1,0);
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			zComponent = new Vector3 (0,0,1);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			zComponent = new Vector3 (0,0,-1);
		}

		Vector3 direction = xComponent + zComponent;
		
		Quaternion lookRotation = Quaternion.LookRotation (direction);

		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
	}
}
