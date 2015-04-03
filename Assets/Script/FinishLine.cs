using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	public bool youWin;

	void Start(){
		youWin = false;
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "shell" || c.tag == "head"){
			youWin = true;
		}
	}
}
