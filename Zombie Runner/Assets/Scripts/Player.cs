using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject landingAreaPrefab;
	public Transform parentSpawnPoints; // parent of spawn points

	private bool respawnToggle = true;
	private Transform[] spawnPoints; 

	// Use this for initialization
	void Start () {
		spawnPoints = parentSpawnPoints.GetComponentsInChildren<Transform>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (respawnToggle) {
			Respawn ();
			respawnToggle = false;
		}
	}

	private void Respawn(){
		int num = Random.Range (1, spawnPoints.Length); // avoid parent at 0 index
		transform.position = spawnPoints [num].position;
	}

	void OnFindClearArea(){
		Invoke ("DropFlare", 3f);
	}

	void DropFlare(){
		Instantiate (landingAreaPrefab, transform.position, Quaternion.identity);
	}
}
