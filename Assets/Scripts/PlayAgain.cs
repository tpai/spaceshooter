using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour {

	public void Restart () {
		Application.LoadLevel (0);
	}
}
