using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	private bool isPauseOn = false;
	private GameObject pauseLabel;
	
	void Start(){
		pauseLabel = GameObject.Find("PauseLabel");
		pauseLabel.SetActive(false);
	}
	
	void OnMouseDown(){
		pauseLabel.SetActive(!isPauseOn);
		if(!isPauseOn){
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;
		}		
		isPauseOn = !isPauseOn;
	}
}
