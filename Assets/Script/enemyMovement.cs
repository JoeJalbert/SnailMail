using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    public Vector3 movementDirection;
    
	void Start () {
	
	}
	
	void Update () {
        
        transform.Translate(movementDirection * Time.deltaTime, Space.World);
	}
    
    void OnCollisionEnter(Collision c){
        //Debug.Log("hit something");
     	if(c.gameObject.tag == "Ground"){
      		movementDirection *= -1;   
     	}

		if(c.gameObject.tag == "head" || c.gameObject.tag == "shell"){
			foreach(GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")){
				if(checkpoint.GetComponent<checkPoint>().isActive == true){
					checkpoint.GetComponent<checkPoint>().Respawn();
					break;
				}
			}
		}
    }
}
