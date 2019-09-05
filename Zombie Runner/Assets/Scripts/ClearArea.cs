using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

	private bool foundClearArea = false;
	private float timeSinceLastTrigger = 0f;
	
	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;
		if (timeSinceLastTrigger > 2f && Time.realtimeSinceStartup > 10f && !foundClearArea) {
			SendMessageUpwards ("OnFindClearArea");
			foundClearArea = true;
		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.tag != "Player")
			timeSinceLastTrigger = 0f;
	}
}
