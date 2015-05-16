using UnityEngine;
using System.Collections;

public class ResetOnEnter : MonoBehaviour {
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			PlayerPrefs.SetInt("CheckpointProgress", 0);
		}
	}
}
