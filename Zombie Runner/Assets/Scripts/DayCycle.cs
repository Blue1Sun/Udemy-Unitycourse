using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

	[Tooltip ("Length of in-game day in minutes")]
	public float lengthOfDay = 6f;

	private float degreesPerSecond = 0f;

	// Use this for initialization
	void Start () {
		degreesPerSecond = 360f / (lengthOfDay * 60f); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime); 
	}
}
