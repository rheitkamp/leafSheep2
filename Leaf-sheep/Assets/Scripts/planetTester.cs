﻿using UnityEngine;
using System.Collections;

public class planetTester : MonoBehaviour {

		public float torque;
		public Rigidbody rb;
		void Start() {
			rb = GetComponent<Rigidbody>();
		}
		void FixedUpdate() {
			float turn = Input.GetAxis("Horizontal");
			rb.AddTorque(transform.up * torque * turn);

	}
}
