using UnityEngine;
using System.Collections;

public class ClearExplo : MonoBehaviour {

	public float lifeTime = 1f;

	void Start () {
		Destroy (gameObject, lifeTime);
	}
}
