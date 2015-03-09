using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	[SerializeField]
	Text topScore, nowScore;
	int topScoreValue;
	static int nowScoreValue;

	void Update () {
		topScoreValue = PlayerPrefs.GetInt ("TopScore");
		nowScoreValue = PlayerPrefs.GetInt ("NowScore");
		topScore.text = topScoreValue.ToString ();
		nowScore.text = nowScoreValue.ToString ();
	}

	public static void AddScore (int amt) {
		nowScoreValue += amt;
		PlayerPrefs.SetInt ("NowScore", nowScoreValue);
	}
}
