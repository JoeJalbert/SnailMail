using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SnailControl : MonoBehaviour {

    public float speed; 
    //public float verticalSpeed = 2.0f;
    float h;
    float v;
    public string input;
	int currDir = 1;

	/*
	public Vector3 velocity;
	public float angle;
	*/
	public Quaternion targetRotation;

    public GameObject wholeObject;
    public GameObject shellPrefab;
    public GameObject shellCurrent;
	public GameObject rotObj;
	public GameObject bodySticker;
    public GameObject colDisplay;
    
    public float distanceFromGround;
    public bool onGround; 
    public float maxVelocity;
	public float distFromBod;
	public float maxDistance;

	public float gradualSpring;

	public Vector3 newMousePos;
    
    public HingeJoint[] hingeJoints;

	public Slider stretchSlider;

	public AudioClip stickSound;
	AudioSource audio;
	
    void Start () {
        onGround = true;

		stretchSlider = GameObject.Find("Stretch_Slider").GetComponent<Slider>();
		stretchSlider.value = 20;

		audio = GetComponent<AudioSource>();
	}
    
	void Update () {

		/*
		velocity = GetComponent<Rigidbody>().velocity;
		angle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
		*/

        
		if(Application.loadedLevel == 2){
		maxDistance = stretchSlider.value;
		}
                
        RaycastHit hit;
        Ray checkRayUp = new Ray(transform.position, Vector3.up);
        Ray checkRayDown = new Ray(transform.position, Vector3.down);
        Ray checkRayLeft = new Ray(transform.position, Vector3.left);
        Ray checkRayRight = new Ray(transform.position, Vector3.right);
        Debug.DrawRay(transform.position, Vector3.down * distanceFromGround);
        
		if(Application.loadedLevel == 2){
			h = speed * Input.GetAxis ("Mouse X") * (stretchSlider.value / 20) ;
		}
		else{
			h = speed * Input.GetAxis ("Mouse X") * Time.deltaTime;
		}
		//v = verticalSpeed * Input.GetAxis ("Mouse Y") ;

		//newMousePos = Input.mousePosition;
		//newMousePos.z = 10;
		//newMousePos = Camera.main.ScreenToWorldPoint(newMousePos);

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			RaycastHit rayHit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit))
			{
				newMousePos = rayHit.point;
			}
		}

		//distFromBod = Vector3.Distance(transform.position, shellCurrent.transform.position);
		//GameObject.Find ("_headMid").GetComponent<CapsuleCollider> ().height = distFromBod * .5f;

		if ((Physics.Raycast (checkRayUp, out hit, distanceFromGround) == false && Physics.Raycast (checkRayDown, out hit, distanceFromGround) == false && Physics.Raycast (checkRayLeft, out hit, distanceFromGround) == false && Physics.Raycast (checkRayRight, out hit, distanceFromGround) == false)) {
			onGround = false;
		}

		if (Input.GetButton (input) && GetComponent<Rigidbody>().velocity.sqrMagnitude < maxVelocity) {

			gradualSpring = 0;

			targetRotation = Quaternion.LookRotation (newMousePos - transform.position);
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 1);

			onGround = false;
			var joint = gameObject.GetComponent<HingeJoint> ();
			Destroy (joint);
			//transform.Rotate (Vector3.forward * Time.deltaTime / 2, Input.GetAxis ("Mouse ScrollWheel") * 100, Space.World);
			this.GetComponent<Rigidbody>().useGravity = false;
			//rigidbody.velocity = new Vector3 (h, v, 0);

			if (Vector3.Distance (transform.position, shellCurrent.transform.position) < maxDistance) {
				//GetComponent<Rigidbody>().AddForce((newMousePos - transform.position) * speed);
				transform.position = Vector3.MoveTowards (transform.position, newMousePos, speed * Time.deltaTime);
				GameObject.Find ("_headEnd").GetComponent<SpringJoint> ().spring = 0;
				GameObject.Find ("_headMid").GetComponent<SpringJoint> ().spring = 0;
			} else {
				transform.position = Vector3.MoveTowards (transform.position, newMousePos, speed * Time.deltaTime);
				GameObject.Find ("_headEnd").GetComponent<SpringJoint> ().spring = 15;
				GameObject.Find ("_headMid").GetComponent<SpringJoint> ().spring = 15;
			}

		} else if (Input.GetKeyDown ("space")) {
			if (shellPrefab != null) {
				//wholeObject.GetComponent<Animation>().Play("shell_anim");
				//if (wholeObject.GetComponent<AnimationState>().time >= wholeObject.GetComponent<AnimationState>().length)
				//{
					Instantiate (shellPrefab, shellCurrent.transform.position, shellCurrent.transform.rotation); 
				//}

			}
			Destroy (wholeObject);
		} 
		else {
			this.GetComponent<Rigidbody>().useGravity = true;
			GameObject.Find("_headMid").GetComponent<SpringJoint>().spring = gradualSpring;
			GameObject.Find("_headEnd").GetComponent<SpringJoint>().spring = gradualSpring;
			gradualSpring = Mathf.Clamp(gradualSpring, 0, 100);
			gradualSpring += .5f;
		}

        if(Physics.Raycast(checkRayUp, out hit, distanceFromGround) || Physics.Raycast(checkRayDown, out hit, distanceFromGround) || Physics.Raycast(checkRayLeft, out hit, distanceFromGround) || Physics.Raycast(checkRayRight, out hit, distanceFromGround)){
            
            Instantiate(colDisplay, hit.point, Quaternion.identity);
            
            if(Input.GetButton(input) != true && hit.collider.tag == "Ground" && onGround == false){
				audio.PlayOneShot (stickSound, .4f);
                var joint = gameObject.AddComponent<HingeJoint>();
                joint.connectedBody = hit.rigidbody;
				joint.enablePreprocessing = false;
				hingeJoints = bodySticker.GetComponents<HingeJoint>();
                foreach(HingeJoint jointB in hingeJoints){
		          	Destroy(jointB);
                }
				onGround = true;
			}

        }
	}
}
