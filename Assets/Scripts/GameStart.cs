using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStart : MonoBehaviour {

	public PlayerMovement playerMovement;
	public EnemySpawner enemySpawner;
	public Animator HUDAnimator;
	Animator anim;
	Text text;

	void Start () {
		text = GetComponent<Text> ();
		anim = GetComponent<Animator> ();
	}

	public void LetsPlay () {
		enemySpawner.StartSpawning ();

		playerMovement.isLock = 1;
		playerMovement.CallWaitForEnter ();

		text.color = Color.clear;
		HUDAnimator.SetBool ("gamestart", true);
		anim.SetBool ("show", false);
		PlayerPrefs.SetInt("NowScore", 0);
	}
}