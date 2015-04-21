using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BodyControl : MonoBehaviour {
    
    public float speed;
    public Transform cam;
    public Vector3 cameraRelativeUp;
    public Vector3 cameraRelativeDown;
    public Vector3 cameraRelativeRight;
    public Vector3 cameraRelativeLeft;    
    
    public Vector3 currentVelocity;
    
    public bool youWin = false;
	
	public Slider massSlider;
	public Slider speedSlider;
    
	void Start () {
        cam = Camera.main.transform;
        cameraRelativeUp = cam.TransformDirection(Vector3.up);
        cameraRelativeDown = cam.TransformDirection(Vector3.down);
        cameraRelativeRight = cam.TransformDirection(Vector3.right);
        cameraRelativeLeft = cam.TransformDirection(Vector3.left);
        GetComponent<Rigidbody>().velocity = GameObject.Find("VelocityPreservation").GetComponent<vPreserve>().swapVelocity;

		massSlider = GameObject.Find("Mass_Slider").GetComponent<Slider>();
		massSlider.value = 60;

		speedSlider = GameObject.Find("Speed_Slider").GetComponent<Slider>();
		speedSlider.value = 450;

	}
	
	void Update () {

		if(Application.loadedLevel == 2){
			this.GetComponent<Rigidbody>().mass = massSlider.value;
			speed = speedSlider.value;
		}

        if(GameObject.Find("_headEnd").GetComponent<HingeJoint>() != null){
	   if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
           GetComponent<Rigidbody>().AddForce(cameraRelativeUp * speed);
       }
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            GetComponent<Rigidbody>().AddForce(cameraRelativeDown * speed);           
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
           GetComponent<Rigidbody>().AddForce(cameraRelativeRight * speed);            
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
           GetComponent<Rigidbody>().AddForce(cameraRelativeLeft * speed);            
        }
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

			//transform.position = GameObject.FindWithTag("Checkpoint").transform.position;
			//transform.rotation = GameObject.FindWithTag ("Checkpoint").transform.rotation;
           	//Application.LoadLevel(Application.loadedLevel);
        }
        if(other.gameObject.tag == "Finish"){
            youWin = true;
        }
    }
    void OnGUI() {
        if(youWin == true){
            GUI.Label(new Rect(300, 309, 500, 300), "You Win!");
			GUI.Label(new Rect(500, 309, 500, 300), "You Win!");
			GUI.Label(new Rect(600, 309, 500, 300), "You Win!");
			GUI.Label(new Rect(600, 309, 500, 300), "You Win!");
			GUI.Label(new Rect(800, 309, 500, 300), "You Win!");
			GUI.Label(new Rect(900, 309, 500, 300), "You Win!");

        }
    }
}
