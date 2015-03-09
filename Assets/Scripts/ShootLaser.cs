using UnityEngine;
using System.Collections;

public class ShootLaser : MonoBehaviour {

	[SerializeField]
	GameObject boltPrefab;
	public float timePerShoot = .5f;

	void Start () {
		if (transform.parent.tag == "Enemy")
			StartShooting ();
	}

	void StartShooting () {
		InvokeRepeating ("ShootBolt", 1f, timePerShoot);
	}
	
	void ShootBolt () {
		Instantiate (boltPrefab, GetComponent<Transform> ().position, Quaternion.identity);
	}
}
