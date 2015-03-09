using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStart : MonoBehaviour {

	public PlayerMovement pm;
	public EnemySpawner es;
	Text t;

	void Start () {
		t = GetComponent<Text> ();
	}

	public void LetsPlay () {
		es.StartSpawning ();

		pm.isLock = 1;
		pm.CallWaitForEnter ();

		t.color = Color.clear;
	}
}
