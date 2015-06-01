using UnityEngine;
using System.Collections;

public class CoffeeDrip : MonoBehaviour {

	private float xPos = 3744.82f;
	private float yPos = 34.1f;
	private float zPos = 44.1f;

	private float ySpeed = 1;

	public float yMin;

	void Update () {
		if(yPos > yMin){
			yPos -= ySpeed;
		}
		else{
			yPos = 120;
		}

		Vector3 tempPos = transform.position;
		tempPos.y = yPos;
		transform.position = tempPos;
	}
}
