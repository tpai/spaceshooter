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

	public int isLock = 0;
	public float movementSpeed = 300f;
	public float rotationSpeed = 5f;
	public CNAbstractController MovementJoystick;

	public void CallWaitForEnter ()
	{
		StartCoroutine ("WaitForEnter");
	}

	IEnumerator WaitForEnter ()
	{
		yield return new WaitForSeconds (.5f);
		isLock = 2;
		boundary.zMin = -5.4f;
		transform.Find ("Laser_Gun").SendMessage("StartShooting");
	}

	void FixedUpdate()
	{
		if (isLock == 1) {
			boundary.zMin = -8f;
			MoveWithEvent (transform.forward);
		}
		else if(isLock == 2) {
			var movement = new Vector3 (
				MovementJoystick.GetAxis ("Horizontal"),
				0f,
				MovementJoystick.GetAxis ("Vertical"));
			CommonMovementMethod (movement);
		}
	}

	void MoveWithEvent(Vector3 mov)
	{
		var movement = new Vector3 (
			mov.x,
			0f,
			mov.z
		);
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
