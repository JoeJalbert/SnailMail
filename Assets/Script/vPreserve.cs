using UnityEngine;
using System.Collections;

public class vPreserve : MonoBehaviour {

    public Vector3 swapVelocity;
    
	void Start () {
	
	}
	
	void Update () {

        if(GameObject.Find("_shellJoint") != null){
         swapVelocity = GameObject.FindWithTag("shell").GetComponent<BodyControl>().currentVelocity;
        }
        else if(GameObject.Find("_shellJ") != null){
         swapVelocity = GameObject.FindWithTag("shell").GetComponent<ShellControl>().currentVelocity;
        }
        
	}
}
