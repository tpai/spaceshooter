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
				HUD.AddScore(10);
				Instantiate(exploAsteroidPrefab, transform.position, Quaternion.identity);
			}
			else if(transform.tag == "Enemy") {
				HUD.AddScore(20);
				Instantiate(exploEnemyPrefab, transform.position, Quaternion.identity);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
