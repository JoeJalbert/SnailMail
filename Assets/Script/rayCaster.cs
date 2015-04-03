using UnityEngine;
using System.Collections;

public class rayCaster : MonoBehaviour {

    public float distanceToWall;
    public bool wallTouch = false;
    private RaycastHit hit;
    
	void Start () {
	}
    
	void Update () {
    Vector3 fwd = transform.TransformDirection(Vector3.right);    
        
	Debug.DrawRay(transform.position, fwd * distanceToWall, Color.green);
        
    if (Physics.Raycast(gameObject.transform.position, fwd, out hit, distanceToWall)) {
        if (hit.collider.gameObject.tag == "ground") {
            wallTouch = true;
        }
    } 
    else {
        wallTouch = false;
    }
	}
}
