using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {

	public float rotationSpeed = 3f; 

	// Use this for initialization
	void Start () {
	
    // get reference to x axis
    // get reference to z axis

	}
	
	// Update is called once per frame
	void Update () {

		float rollForwardsOrBackwards = -Input.GetAxis ("Vertical") * rotationSpeed;
		float rollLeftOrRight = -Input.GetAxis ("Horizontal") * rotationSpeed;

		transform.Rotate (rollLeftOrRight, 0, rollForwardsOrBackwards);
    // if pressing left or right arrow keys, rotate on z axis
    // if pressing up or down arrow keys, rotate on x axis

    // also need to add code for rotating sheep toward direction of motion

	}
}
