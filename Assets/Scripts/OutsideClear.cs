using UnityEngine;
using System.Collections;

public class OutsideClear : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Destroy (other.gameObject);
	}
}
