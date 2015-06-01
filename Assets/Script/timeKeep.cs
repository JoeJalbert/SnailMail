using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeKeep : MonoBehaviour {

	public Text timer;
	public static float time;
	public float seconds;
	public float minutes;

	void Awake () {
		seconds = 0;
		minutes = 0;
	}

	void Update () {
		if(GameObject.FindWithTag("Finish").GetComponent<FinishLine>().youWin == false){
			time += Time.deltaTime;
		}
		else if((minutes * 60 + seconds) < PlayerPrefs.GetFloat("BestTime", 9999)){
			PlayerPrefs.SetFloat ("BestTime", ((minutes * 60) + seconds));
		}
		minutes = Mathf.Floor(time/60);
		seconds = Mathf.RoundToInt (time%59);
		if(seconds < 10 && minutes < 10){
			timer.text = " 0" + minutes.ToString () + ":0" + seconds.ToString () + "";
		}
		else if(seconds < 10 && minutes >= 10){
			timer.text = " " + minutes.ToString () + ":0" + seconds.ToString () + "";
		}
		else if(minutes < 10 && seconds >= 10){
			timer.text = " 0" + minutes.ToString () + ":" + seconds.ToString () + "";
		}
	}
}
