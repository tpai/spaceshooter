using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[System.Serializable]
	public class Done_Boundary 
	{
		public float xMin, xMax, zMin, zMax;
	}
	public Done_Boundary boundary;

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
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			rigidbody.position.y, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -rotationSpeed);
	}
}
