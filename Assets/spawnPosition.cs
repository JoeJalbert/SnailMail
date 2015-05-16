using UnityEngine;
using System.Collections;

public class spawnPosition : MonoBehaviour {
	void Awake () {
		foreach(GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")){
			if(PlayerPrefs.GetInt("CurrentStage") == checkpoint.GetComponent<checkPoint>().checkPointNum){
				transform.position = checkpoint.transform.position;
			}
		}
	}
}
