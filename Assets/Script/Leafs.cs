using UnityEngine;
using System.Collections;

public class Leafs : MonoBehaviour {

	void OnCollisionEnter() {
		GetComponent<Rigidbody>().drag = 0;
	}
}
