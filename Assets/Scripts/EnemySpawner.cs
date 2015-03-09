using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public float spawnSpeed = 1f;

	public void StartSpawning () {
		InvokeRepeating ("SpawnNow", 1f, spawnSpeed);
	}

	void SpawnNow () {
		Instantiate (
			enemyPrefabs [Random.Range (0, enemyPrefabs.Length)],
			new Vector3 (
				Random.Range (-3.4f, 3.4f),
				1f,
				8f
			),
			Quaternion.identity
		);
	}
}
