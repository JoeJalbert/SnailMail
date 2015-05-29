using UnityEngine;
using System.Collections;

public class deletePlayerPrefs : MonoBehaviour {
	
	public void deleteCheck () {
		PlayerPrefs.SetInt("CheckpointProgress", 0);
	}
}
