using UnityEngine;
using System.Collections;

public class dontDestroyOnLoad : MonoBehaviour {

	public static dontDestroyOnLoad Instance;

	void Awake () {
		if(Instance){
			DestroyImmediate(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}	
	}
}
