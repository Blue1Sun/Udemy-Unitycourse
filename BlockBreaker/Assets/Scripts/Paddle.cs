using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		} 
		else{
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		Vector3 newPos = new Vector3 (0, this.transform.position.y, this.transform.position.z);
		newPos.x = Mathf.Clamp(ball.transform.position.x, 1f, 15f);
		this.transform.position = newPos;
	}
	
	void MoveWithMouse (){
		Vector3 newPos = new Vector3 (0, this.transform.position.y, this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		newPos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
		this.transform.position = newPos;
	}
}
