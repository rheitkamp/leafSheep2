using UnityEngine;
using System.Collections;

public class testLeafSheepMove : MonoBehaviour {

	public float speed = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}
}
