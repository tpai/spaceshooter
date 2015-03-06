using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject exploEnemyPrefab, exploAsteroidPrefab, exploPlayerPrefab;
	float velX, velZ;

	void Start () {
		velX = Random.Range (-1f, 1f);
		velZ = Random.Range (-5f, -3f);
	}
	
	void Update () {
		rigidbody.velocity = new Vector3 (velX, 0, velZ);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Instantiate(exploPlayerPrefab, other.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
		}

		if(other.tag == "Ammo") {
			if(transform.tag == "Asteroid") {
				Instantiate(exploAsteroidPrefab, transform.position, Quaternion.identity);
			}
			else if(transform.tag == "Enemy") {
				Instantiate(exploEnemyPrefab, transform.position, Quaternion.identity);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
