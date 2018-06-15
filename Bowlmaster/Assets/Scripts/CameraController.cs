using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Ball ball;

	private float offset;

	// Use this for initialization
	void Start () {
		offset = transform.position.z - ball.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosZ = ball.transform.position.z + offset;
		newPosZ = Mathf.Clamp (newPosZ, offset, 1829 + offset);
		transform.position = new Vector3(transform.position.x, transform.position.y, newPosZ);
	}
}
