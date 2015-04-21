using UnityEngine;
using System.Collections;

public class ShellControl : MonoBehaviour {

	public float rollSpeed = 120;
    public GameObject wholeObject;
    public GameObject snailPrefab;
    public GameObject shellCurrent;
    
    public Vector3 currentVelocity;
    
    public bool youWin = false;
    
	void Start () {
        GetComponent<Rigidbody>().velocity = GameObject.Find("VelocityPreservation").GetComponent<vPreserve>().swapVelocity;;
	}
	
	void Update () {
        if(Input.GetKey("d")){
         GetComponent<Rigidbody>().AddForce(rollSpeed, 0, 0);   
        }
        if(Input.GetKey("a")){
         GetComponent<Rigidbody>().AddForce(-rollSpeed,0,0);   
        }
	   if(Input.GetKeyDown("space")){
            if(snailPrefab != null){
                Instantiate(snailPrefab, shellCurrent.transform.position, shellCurrent.transform.rotation); 
            }
            Destroy(wholeObject);
        }
        currentVelocity = GetComponent<Rigidbody>().velocity;
	}
    
    void OnTriggerEnter(Collider other){
        Debug.Log("Hit the collider");
        if(other.gameObject.tag == "death"){ 
			foreach(GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")){
				if(checkpoint.GetComponent<checkPoint>().isActive == true){
					checkpoint.GetComponent<checkPoint>().Respawn();
					break;
				}
			}
			//GameObject.FindWithTag("Checkpoint").GetComponent<checkPoint>().Respawn();
        }
        if(other.gameObject.tag == "Finish"){
            youWin = true;
        }
    }
    void OnGUI() {
        if(youWin == true){
        GUI.Label(new Rect(300, 309, 500, 300), "You Win!");
        }
    }
}
