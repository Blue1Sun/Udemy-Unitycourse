using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider collider){
		if (collider.GetComponent<Pin> ()) {
			Destroy (collider.gameObject);
		}
	}
}
