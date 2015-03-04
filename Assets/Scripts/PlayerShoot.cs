using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	[SerializeField]
	GameObject boltPrefab;
	public float timePerShoot = .5f;

	void Start () {
		InvokeRepeating ("ShootBolt", 0f, timePerShoot);
	}
	
	void ShootBolt () {
		Instantiate (boltPrefab, GetComponent<Transform> ().position, Quaternion.identity);
	}
}
