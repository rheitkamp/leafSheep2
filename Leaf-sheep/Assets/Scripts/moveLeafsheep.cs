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

		// Move and turn the tank.
		Move ();
		Turn ();

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
