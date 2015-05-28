using UnityEngine;
using System.Collections;

public class spawnPoint : MonoBehaviour {

	public int checkSpawn;

	void Awake () {
	
		checkSpawn = PlayerPrefs.GetInt ("CurrentStage");
		GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
		foreach(GameObject checkpoint in checkPoints){
			if(checkSpawn == checkpoint.GetComponent<checkPoint>().checkPointNum){
				transform.position = checkpoint.transform.position;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
