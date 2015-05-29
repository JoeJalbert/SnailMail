using UnityEngine;
using System.Collections;

public class speedBoost : MonoBehaviour {

	public int rollSpeed = 150;

	void OnTriggerEnter (Collider c) {
		if(c.tag == "shell"){
			c.GetComponent<ShellControl>().rollSpeed += rollSpeed;
		}
	}
}
