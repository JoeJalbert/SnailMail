using UnityEngine;
using System.Collections;

public class spawnPosition : MonoBehaviour {
	void Awake () {
		if(PlayerPrefs.GetInt ("IsLoaded") == 0){
			foreach(GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")){
				if(PlayerPrefs.GetInt("CurrentStage") == checkpoint.GetComponent<checkPoint>().checkPointNum){
					transform.position = checkpoint.transform.position;
				}
			}
		PlayerPrefs.SetInt ("IsLoaded", 1);
		}
		else if(PlayerPrefs.GetInt("IsLoaded") == null){
			PlayerPrefs.SetInt ("IsLoaded", 0);
			Application.LoadLevel (1);
		}
	}
}
