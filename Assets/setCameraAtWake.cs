using UnityEngine;
using System.Collections;

public class setCameraAtWake : MonoBehaviour {
	void Awake () {
		GetComponent<Canvas>().worldCamera = Camera.main;
		if(GameObject.FindWithTag ("head") != null) {
			GameObject.FindWithTag("head").GetComponent<SnailControl>().enabled = false;
			GameObject.FindWithTag("head").GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

		}
		else{
			GameObject.FindWithTag("shell").GetComponent<ShellControl>().enabled = false;
			GameObject.FindWithTag("shell").GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			GameObject.FindWithTag("shell").GetComponent<ShellControl>().rollSpeed = 0;
			GameObject.FindWithTag("shell").GetComponent<Rigidbody>().drag = 1000;

		}
	}

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			if(GameObject.FindWithTag ("head") != null) {
				GameObject.FindWithTag ("head").GetComponent<SnailControl>().enabled = true;
			}
			else{
				GameObject.FindWithTag("shell").GetComponent<ShellControl>().enabled = true;
				GameObject.FindWithTag("shell").GetComponent<ShellControl>().rollSpeed = 120;
				GameObject.FindWithTag("shell").GetComponent<Rigidbody>().drag = 0;


			}
			Destroy (this.gameObject);
		}
	}
}
