using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {

	public float rotationSpeed = 3f;
    public Rigidbody rb; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
		// rotate leaf sheep toward opposite of direction of motion
		// when leaf sheep is facing direction of motion, move the planet beneath


			// if pressing up or down arrow keys, rotate on x axis
			float rollForwardsOrBackwards = -Input.GetAxis ("Vertical") * rotationSpeed;
			// if pressing left or right arrow keys, rotate on z axis
			float rollLeftOrRight = -Input.GetAxis ("Horizontal") * rotationSpeed;

        //in order for collisions to be detected correctly, movement has to be dependent on force/torque added, not position change
		rb.AddRelativeTorque(rollLeftOrRight, 0f, rollForwardsOrBackwards);
        /*
        transform.Rotate (rollLeftOrRight, 0, rollForwardsOrBackwards, Space.World);
        */
    }
}
