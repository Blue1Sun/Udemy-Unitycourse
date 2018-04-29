using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

public float autoLoadNextLevelAfter = 0;

void Start(){
	if (autoLoadNextLevelAfter <= 0)
		Debug.Log("Error with Level Auto Load");
	else
		Invoke("LoadNextLevel", autoLoadNextLevelAfter);
}
	
public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
public void QuitRequest(){
		Application.Quit();
	}
	
public void LoadNextLevel(){
	Application.LoadLevel(Application.loadedLevel + 1);
}
}
