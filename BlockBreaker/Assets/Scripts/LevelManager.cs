using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
public void LoadLevel(string name){
		Brick.breackableNumber = 0;
		Application.LoadLevel(name);
	}
public void QuitRequest(){
		Application.Quit();
	}
	
public void LoadNextLevel(){
	Brick.breackableNumber = 0;
	Application.LoadLevel(Application.loadedLevel + 1);
}
}
