using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyContact : MonoBehaviour {

	Animator HUDAnimator;
	Animator playAgainAnimator;
	Text finalScoreText;

	public GameObject exploEnemyPrefab, exploAsteroidPrefab, exploPlayerPrefab;

	void Start () {
		HUDAnimator = GameObject.Find ("HUD").GetComponent<Animator> ();
		playAgainAnimator = GameObject.Find ("PlayAgain").GetComponent<Animator> ();
		finalScoreText = GameObject.Find ("FinalScore").GetComponent<Text> ();
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {

			int topScore = PlayerPrefs.GetInt("TopScore");
			int nowScore = PlayerPrefs.GetInt("NowScore");
			if(nowScore > topScore)PlayerPrefs.SetInt("TopScore", nowScore);

			HUDAnimator.SetBool("gamestart", false);
			playAgainAnimator.SetBool("show", true);
			finalScoreText.text = nowScore.ToString();
			finalScoreText.color = Color.white;

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
