using UnityEngine;
using System.Collections;

public class BoltClear : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Ammo") {
			Destroy (other.gameObject);
		}
	}
}
