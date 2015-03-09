using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStart : MonoBehaviour {

	public PlayerMovement playerMovement;
	public EnemySpawner enemySpawner;
	public Animator HUDAnimator;
	Text text;

	void Start () {
		text = GetComponent<Text> ();
	}

	public void LetsPlay () {
		enemySpawner.StartSpawning ();

		playerMovement.isLock = 1;
		playerMovement.CallWaitForEnter ();

		text.color = Color.clear;
		HUDAnimator.SetBool ("gamestart", true);
	}
}