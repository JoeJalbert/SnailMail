using UnityEngine;
using System.Collections;
using System.Linq;

public class checkPoint : MonoBehaviour {

	public GameObject[] Player;
	public bool isActive = false;

	public GameObject[] checkpoints;

	public GameObject snailPrefab;

	public int checkPointNum;

	void Start(){
		checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").OrderBy( go => go.name ).ToArray();
	}

	void Update () {
				
		/*
		if(Player.transform.position.x > this.transform.position.x && isActive == false){
			foreach(GameObject checkpoint in checkpoints){
				if(checkpoint == this.gameObject){continue;}
				Destroy(checkpoint);
			}
			isActive = true;
			this.tag = "Checkpoint";
		}
		else{
			isActive = false;
		}
		*/

		if(Input.GetKeyDown (KeyCode.Return) && isActive == true){
			foreach(GameObject checkpoint in checkpoints){
				//if(checkpoint == this.gameObject){continue;}
				if(checkpoint.GetComponent<checkPoint>().checkPointNum == (this.checkPointNum + 1) && this.isActive == true){
					//checkpoint.tag = "Checkpoint";
					//if(checkpoint.GetComponent<checkPoint>().isActive == false){
					checkpoint.GetComponent<checkPoint>().isActive = true;
					//Respawn ();
					break;
					//}
				}
			}
			isActive = false;
			Respawn ();
			/*
			if(isActive == true){
				Destroy(gameObject);
			}

			if(this.tag == "Checkpoint"){
				Destroy(gameObject);
			}
			*/

		}
	}

	public void Respawn(){;
		Player = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject checkpoint in checkpoints){
			if(checkpoint.GetComponent<checkPoint>().isActive == true){
				foreach(GameObject player in Player){
				Destroy(player);
				}
				Instantiate (snailPrefab, checkpoint.transform.position, snailPrefab.transform.rotation);
				break;
			}
		}
		/*
		if(this.tag == "Checkpoint"){
			Instantiate (snailPrefab, transform.position, snailPrefab.transform.rotation);
		}
		*/
	}

	void OnTriggerEnter(Collider c){
		//if(c.tag == "shell" && isActive == false){
			foreach(GameObject checkpoint in checkpoints){
				//if(checkpoint == this.gameObject){continue;}
				//if(checkpoint.GetComponent<checkPoint>().isActive == true){
					checkpoint.GetComponent<checkPoint>().isActive = false;
				//}
			}
			isActive = true;
			//this.tag = "Checkpoint";
		//}
	}
}
