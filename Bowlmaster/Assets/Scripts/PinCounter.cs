using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1; 
	private int lastSettledCount = 10;
	private float lastChangeTime;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			CheckStanding ();
		}
	}

	public void Reset (){
		lastSettledCount = 10;
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name == "Ball") {
			standingDisplay.color = Color.red;
			ballOutOfPlay = true;
		}
	}

	void CheckStanding(){
		int currentStanding = CountStanding ();

		//count changed
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; // How long to wait
		if((Time.time - lastChangeTime) > settleTime){
			PinsHaveSettled ();
			standingDisplay.color = Color.cyan;
		}
	}

	void PinsHaveSettled(){
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl (pinFall);

		lastStandingCount = -1; //Indicates pins have settled
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding(){
		int numOfStanding = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding())
				numOfStanding++;
		}
		return numOfStanding;
	} 
}
