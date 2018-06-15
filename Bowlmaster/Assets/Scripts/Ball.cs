using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Vector3 ballStartPos;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().useGravity = false;

		ballStartPos = transform.position;
	}

	public void Launch (Vector3 velocity){
		if (!inPlay) {
			inPlay = true;

			GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<Rigidbody> ().velocity = velocity;

			GetComponent<AudioSource> ().Play ();
		}
	}

	public void Reset () {
		transform.position = ballStartPos;

		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;

		GetComponent<AudioSource> ().Stop ();

		GetComponent<Transform> ().rotation = Quaternion.identity;
	}
}
