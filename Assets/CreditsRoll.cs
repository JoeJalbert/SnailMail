using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsRoll : MonoBehaviour {
	void Update () {
		if(GameObject.FindWithTag("Finish").GetComponent<FinishLine>().youWin == true){
			Vector3 tempPos = transform.position;
			tempPos.y += 1;
			transform.position = tempPos;

			if(tempPos.y > 1500){
				Application.LoadLevel(0);
			}
		}
	}
}
