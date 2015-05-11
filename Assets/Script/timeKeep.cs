using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeKeep : MonoBehaviour {

	public Text timer;
	public static float time;
	public float seconds;
	public float minutes;

	void Start () {
	}

	void Update () {
		if(GameObject.FindWithTag("Finish").GetComponent<FinishLine>().youWin == false){
		time += Time.deltaTime;
		}
		minutes = Mathf.Floor(time/60);
		seconds = Mathf.RoundToInt (time%60);
		timer.text = " " + minutes.ToString () + ":" + seconds.ToString () + "";
	}
}
