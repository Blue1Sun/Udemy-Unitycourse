using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> bowls = new List<int> ();

	private ScoreDisplay scoreDisplay;
	private PinSetter pinSetter;
	private Ball ball;

	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();
	}
	
	public void Bowl (int pinFall){
		
		bowls.Add (pinFall);

		pinSetter.PerformAction (ActionMaster.NextAction (bowls));
		try {
			scoreDisplay.FillRolls (bowls);
			scoreDisplay.FillFrames (ScoreMaster.ScoreCumulative(bowls));
		}
		catch {
			Debug.LogWarning ("SMT wrong");
		}

		ball.Reset ();
	}
}
