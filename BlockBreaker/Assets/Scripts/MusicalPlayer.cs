using UnityEngine;
using System.Collections;

public class MusicalPlayer : MonoBehaviour {
	static MusicalPlayer instance = null;
	
	void Awake(){
		//Debug.Log ("Music player AWAKE " + GetInstanceID());
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
