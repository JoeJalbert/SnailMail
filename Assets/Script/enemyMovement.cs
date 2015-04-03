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
			GameObject.FindWithTag("Checkpoint").GetComponent<checkPoint>().Respawn();
		}
    }
}
