using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	void OnTriggerEnter2D(){
		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("03b Lose");
	}
}
