using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	[System.Serializable]
	public class Done_Boundary 
	{
		public float xMin, xMax;
	}
	public Done_Boundary boundary;

	public float movementSpeed = 80f;
	public float rotationSpeed = 20f;
	public bool isJet = false;
	float velX, velZ;

	void Start () {
		StartCoroutine ("Evade");
	}

	IEnumerator Evade () {
		velX = Random.Range (-1f, 1f);
		velZ = Random.Range (-4f, -3f);
		if (isJet) {
			yield return new WaitForSeconds(1f);
			velX = 0f;
		}
	}

	void FixedUpdate () {

		var movement = new Vector3 (
			velX,
			0f,
			velZ
		);
		CommonMovementMethod (movement);
	}

	private void CommonMovementMethod(Vector3 movement)
	{
		rigidbody.velocity = movement * movementSpeed * Time.deltaTime;
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			rigidbody.position.y, 
			rigidbody.position.z
		);
		rigidbody.rotation = Quaternion.Euler (0.0f, -180f, rigidbody.velocity.x * rotationSpeed);
	}
}
