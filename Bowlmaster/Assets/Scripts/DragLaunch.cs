using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;
	private float ballSize;

	void Start () {
		ball = GetComponent<Ball> ();
		ballSize = GetComponent<Transform> ().localScale.x;
	}

	public void MoveStart (float amount){
		if (!ball.inPlay) {
			if (amount < 0)
				InvokeRepeating ("MovingLeft", 0.000001f, 0.0001f);
			else
				InvokeRepeating ("MovingRight", 0.000001f, 0.0001f);
		}
	}

	public void StopMoveStart (){
		CancelInvoke ();
	}

	private void MovingLeft (){
		if (ball.transform.position.x > -(105/2 - ballSize/2))
			ball.transform.Translate (Vector3.left * 0.1f);
	}

	private void MovingRight (){
		if (ball.transform.position.x < (105/2 - ballSize/2))
			ball.transform.Translate (Vector3.right * 0.1f);
	}
	
	public void DragStart(){
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd(){
		dragEnd = Input.mousePosition;
		endTime = Time.time;

		//Calculating launch velocity
		float dragDuration = (endTime - startTime) * 1.1f;

		float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

		Vector3 launchVelocity = new Vector3(launchSpeedX*0.8f, 0, launchSpeedZ);

		if (!float.IsNaN (launchSpeedX) && !float.IsNaN (launchSpeedZ))
			ball.Launch (launchVelocity);
	}
}
