using UnityEngine;
using System.Collections;
using System.Linq;

public class checkPoint : MonoBehaviour {

	public GameObject[] Player;
	public bool isActive = false;

	public GameObject[] checkpoints;

	public GameObject snailPrefab;

	public int checkPointNum;

	private bool backingUp = false;

	public bool hasBeenTouched;

	public GameObject letterCanvas;

	void Start(){
		checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").OrderBy( go => go.name ).ToArray();
	}

	/*
	void Update () {

		if(Input.GetKeyDown (KeyCode.Return) && isActive == true){
			checkpoints[checkPointNum].GetComponent<checkPoint>().isActive = true;
			isActive = false;
			Respawn ();
		}
		if(Input.GetKeyDown (KeyCode.Backspace) && isActive == true){
			checkpoints[checkPointNum-2].GetComponent<checkPoint>().isActive = true;
			backingUp = true;
			Respawn ();
		}

	}
	*/

	public void Respawn(){;
				Player = GameObject.FindGameObjectsWithTag("Player");

				foreach(GameObject player in Player){
					Destroy(player);
				}
				//if(isActive == true){
					Instantiate (snailPrefab, transform.position, snailPrefab.transform.rotation);
				//}
				
	}

	void OnTriggerEnter(Collider c){
		if(isActive == false){
			foreach(GameObject checkpoint in checkpoints){
				if(checkpoint == this.gameObject){
					continue;
				}
				else if(checkpoint.GetComponent<checkPoint>().isActive == true){
					checkpoint.GetComponent<checkPoint>().isActive = false;
				}
			}
		}
		if(hasBeenTouched == false && (c.tag == "shell" || c.tag == "head")){
			Instantiate(letterCanvas, new Vector3(0,0,0), Quaternion.identity);
			hasBeenTouched = true;
			if(PlayerPrefs.GetInt ("CheckpointProgress") < checkPointNum - 1){
				PlayerPrefs.SetInt ("CheckpointProgress", checkPointNum - 1);
			}
		}
		if(c.tag == "shell" || c.tag == "head"){
			isActive = true;
		}
	}
}
