using UnityEngine;
using System.Collections;

public class speedBoost : MonoBehaviour {

	void Start () {
	
	}

	void OnTriggerEnter (Collider c) {
		if(c.tag == "shell"){
			c.GetComponent<ShellControl>().rollSpeed += 150;
		}
	}
}
