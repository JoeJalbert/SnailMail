using UnityEngine;
using System.Collections;

public class delayDestroy : MonoBehaviour {

	void Start () {
		//Destroy (gameObject);
        StartCoroutine(DestroyQuick());
	}
    IEnumerator DestroyQuick(){
        yield return new WaitForSeconds(.01f);
        Destroy (gameObject);
    }
}
