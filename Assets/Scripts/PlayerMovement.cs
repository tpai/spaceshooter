using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 300f;
	public float rotationSpeed = 5f;
	public CNAbstractController MovementJoystick;

	void FixedUpdate()
	{
		var movement = new Vector3(
			MovementJoystick.GetAxis("Horizontal"),
			0f,
			MovementJoystick.GetAxis("Vertical"));
		CommonMovementMethod(movement);
	}

	private void CommonMovementMethod(Vector3 movement)
	{
		rigidbody.velocity = movement * movementSpeed * Time.deltaTime;
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -rotationSpeed);
	}
}
