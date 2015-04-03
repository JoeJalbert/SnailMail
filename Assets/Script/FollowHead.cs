using UnityEngine;
using System.Collections;

public class FollowHead : MonoBehaviour {

    public float distance;
    private float speed;
    public GameObject following;
    public Transform target;
    
	void Start () {
	
	}
	
	void Update () {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        //transform.LookAt(target);
        //transform.rotation = Quaternion.FromToRotation(Vector3.right, Vector3.forward) * transform.rotation;
        
	   /*
       if(following.rigidbody.transform.position.y > (rigidbody.transform.position.y + distance)){
           rigidbody.transform.position += Vector3.up * speed * Time.deltaTime;
       }
       if(following.rigidbody.transform.position.y < (rigidbody.transform.position.y - distance)){
           rigidbody.transform.position += Vector3.down * speed * Time.deltaTime;
       }
       if(following.rigidbody.transform.position.x > (rigidbody.transform.position.x + distance)){
           rigidbody.transform.position += Vector3.right * speed * Time.deltaTime;
       }
       if(following.rigidbody.transform.position.x < (rigidbody.transform.position.x - distance)){
           rigidbody.transform.position += Vector3.left * speed * Time.deltaTime;
       }
        */
        /*
        if(following.rigidbody.transform.rotation.eulerAngles.z <  rigidbody.transform.rotation.eulerAngles.z){
            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = 1;
            transform.rotation = Quaternion.Euler(temp);
        }
        */
        if(Input.GetButton("Fire1") == false){
            speed = 1;
        }
        else{
         speed = 1;   
        }
    }
}
