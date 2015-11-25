using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {

	public Vector3 eulerAngleVelocity;

	Rigidbody worldRB;
	public float rotationSpeed = 15f; 

	void Start (){
		worldRB = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		// rotate leaf sheep toward opposite of direction of motion
		// when leaf sheep is facing direction of motion, move the planet beneath

			// if pressing up or down arrow keys, rotate on x axis
			//float rollForwardsOrBackwards = -Input.GetAxis ("Vertical") * rotationSpeed;
			// if pressing left or right arrow keys, rotate on z axis
			//float rollLeftOrRight = -Input.GetAxis ("Horizontal") * rotationSpeed;
			
			//worldRB.AddTorque(transform.forward * rollForwardsOrBackwards);
			//worldRB.AddTorque (transform.right * rollLeftOrRight);

		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		worldRB.MoveRotation (worldRB.rotation * deltaRotation);

	}
}
	