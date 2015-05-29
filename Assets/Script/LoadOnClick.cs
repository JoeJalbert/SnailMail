using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int level)
	{
		loadingImage.SetActive (true);
		Application.LoadLevel(1);
		PlayerPrefs.SetInt ("CurrentStage", level);
		PlayerPrefs.SetInt ("IsLoaded", 0);
	}

	public void ExitScene()
	{
		Application.Quit();
	}

}
