using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

static public int dificulty;
	
public	void LoadLevel(string name){
		//Debug.Log("Level load requested for " + name);
		dificulty = 5;
		Application.LoadLevel(name);
	}

public void HardMode(string name){
	dificulty = 15;
	Application.LoadLevel(name);
}

public void QuitRequest(){
		//Debug.Log("I wanna quit");
		Application.Quit();
	}
}
