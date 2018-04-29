using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	void OnMouseDown(){
		GameObject.FindObjectOfType<LevelManager>().LoadLevel("01a Start");
	}
}
