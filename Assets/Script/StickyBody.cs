using UnityEngine;
using System.Collections;

public class StickyBody : MonoBehaviour {

    //public Transform moveTowards;
    //public float speed = .05f;
    public float distanceFromGround = 2;
    public GameObject colDisplay;
    
	void Start () {
	
	}

	void Update () {

		/*
        if(gameObject.GetComponent<HingeJoint>() == null){
            GameObject.Find("headM").GetComponent<SpringJoint>().spring = 50;
            GameObject.Find("headE").GetComponent<SpringJoint>().spring = 50;
            transform.position = Vector3.MoveTowards(transform.position, moveTowards.position, speed);
        }
        else{
            GameObject.Find("headM").GetComponent<SpringJoint>().spring = 0;
            GameObject.Find("headE").GetComponent<SpringJoint>().spring = 0;
        }
        */
        
        
        RaycastHit hit;
        Ray checkRayUp = new Ray(transform.position, Vector3.up);
        Ray checkRayDown = new Ray(transform.position, Vector3.down);
        Ray checkRayLeft = new Ray(transform.position, Vector3.left);
        Ray checkRayRight = new Ray(transform.position, Vector3.right);
        Debug.DrawRay(transform.position, Vector3.down * distanceFromGround);
        
        if(Physics.Raycast(checkRayUp, out hit, distanceFromGround) || Physics.Raycast(checkRayDown, out hit, distanceFromGround) || Physics.Raycast(checkRayLeft, out hit, distanceFromGround) || Physics.Raycast(checkRayRight, out hit, distanceFromGround)){
            
            Instantiate(colDisplay, hit.point, Quaternion.identity);
            
            if(Input.GetButtonDown("Fire1") == true && hit.collider.tag == "Ground"){
                var joint = gameObject.AddComponent<HingeJoint>();
				joint.enablePreprocessing = false;
                joint.connectedBody = hit.rigidbody;
            }
        }
	}
    /*
	void OnCollisionEnter(Collision c){
		if(Input.GetButton("Fire1") && c.gameObject.tag == "Ground"){
			var joint = gameObject.AddComponent<HingeJoint>();
			joint.connectedBody = c.rigidbody;
		}
	}
    */
}
