using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int level)
	{
		loadingImage.SetActive (true);
		Application.LoadLevel(1);
		PlayerPrefs.SetInt ("CurrentStage", level);
	}

	public void ExitScene()
	{
		Application.Quit();
	}

}
