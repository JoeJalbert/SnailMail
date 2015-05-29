using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkIfEnabled : MonoBehaviour {

	public int checkPointNum;

	void Update () {
		if(PlayerPrefs.GetInt ("CheckpointProgress") < checkPointNum){
			GetComponent<Button>().interactable = false;
		}
		else{
			GetComponent<Button>().interactable = true;
		}
	}
}
