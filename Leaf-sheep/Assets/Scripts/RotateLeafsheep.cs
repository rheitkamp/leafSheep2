using UnityEngine;
using System.Collections;

public class RotateLeafsheep : MonoBehaviour {

	public float smooth = 2.0F;
	public GameObject leafster;

	Quaternion target = Quaternion.identity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// rotate leaf sheep toward opposite of direction of motion

		//rotation is around y axis only
		if (Input.GetAxis ("Horizontal") > 0) {
			target = Quaternion.Euler (0f, 180f, 0f);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			target = Quaternion.Euler (0f, 0f, 0f);
		}

		if (Input.GetAxis ("Vertical") > 0) {
			target = Quaternion.Euler (0f, 90f, 0f);
		} else if (Input.GetAxis ("Vertical") < 0) {
			target = Quaternion.Euler (0f, 270f, 0f);
		} 
		
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);

		//Debug.Log(leafster.GetComponent<Rigidbody>().IsSleeping());
	}
}
