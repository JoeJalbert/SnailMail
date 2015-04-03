using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    public GameObject target;
    public float zposition;
    public float zoomer;
    
	void Start () {
	
	}
	
	void Update () {

		if(Input.GetKey(KeyCode.Escape)){
			Application.LoadLevel (0);
		}

        target = GameObject.FindWithTag("shell");
        Vector3 temp = target.transform.position;
        temp.z = zposition;
        transform.position = temp;

        GetComponent<Camera>().orthographicSize = zoomer;
        zoomer += Input.GetAxis("Mouse ScrollWheel") * -5;
	}
}
