using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	private float standingThreshold = 3f;
	private float distToRaise = 40f;

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs (270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs (rotationInEuler.z);
	
		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
			return true;
		} else {
			return false;
		}
	}

	public void RaiseIfStanding(){
		if (IsStanding ()) {
			transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
			GetComponent<Transform> ().rotation = Quaternion.Euler (270f, 0, 0);  
			GetComponent<Rigidbody> ().useGravity = false;
		}
	}

	public void Lower(){
		transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
		GetComponent<Rigidbody> ().useGravity = true;
		GameObject.FindObjectOfType<Ball> ().inPlay = false;
	}

	void Awake () {
		this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
	}
}
