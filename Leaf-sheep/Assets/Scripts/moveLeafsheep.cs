using UnityEngine;
using System.Collections;

public class moveLeafsheep : MonoBehaviour {
	public float moveSpeed = 10f;
	public float turnSpeed = 180f;
	public Rigidbody rb; 

	private string movementAxisName = "Vertical";
	private string turnAxisName = "Horizontal";
	private float movementInputValue;
	private float turnInputValue;

	
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void Update()
	{
		// Store the player's input and make sure the audio for the engine is playing.
		movementInputValue = Input.GetAxis (movementAxisName);
		turnInputValue = Input.GetAxis (turnAxisName);
	}

	void FixedUpdate () {
		// rotate leaf sheep toward opposite of direction of motion
		// when leaf sheep is facing direction of motion, move the planet beneath

		// Move and turn the tank.
		Move ();
		Turn ();

		/*
		// if pressing up or down arrow keys, rotate on x axis
		float verticalInput = -Input.GetAxis ("Vertical") * moveSpeed;

		// if pressing left or right arrow keys, rotate on z axis
		float moveLeftOrRight = Input.GetAxis ("Horizontal") * moveSpeed;
		
		rb.AddForce (transform.right * verticalInput);
		//rb.AddForce (transform.forward * verticalInput);
		//rb.AddForce (transform.right * moveLeftOrRight);

		//transform.Rotate (rollLeftOrRight, 0, rollForwardsOrBackwards, Space.World);
		*/
	}

	private void Move()
	{
		// Adjust the position of the tank based on the player's input.
		Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
		
		rb.MovePosition (rb.position + movement);
	}
	
	
	private void Turn()
	{
		// Adjust the rotation of the tank based on the player's input.
		float turn = turnInputValue * turnSpeed * Time.deltaTime;
		
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		
		rb.MoveRotation (rb.rotation * turnRotation);
		
	}


}
