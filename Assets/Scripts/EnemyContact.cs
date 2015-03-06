using UnityEngine;
using System.Collections;

public class EnemyContact : MonoBehaviour {

	public GameObject exploEnemyPrefab, exploAsteroidPrefab, exploPlayerPrefab;
	
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
