using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
		foreach (Text text in rollTexts)
			text.text = " ";
		foreach (Text text in frameTexts)
			text.text = " ";
	}

	public void FillRolls (List<int> rolls){
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts [i].text = scoresString [i].ToString ();
		}
	}

	public void FillFrames (List<int> frames){
		for (int i = 0; i < frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
		}
	}

	public static string FormatRolls(List<int> rolls){
		string output = "";
		 
		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1;

			if (rolls [i] == 0) { // Zero
				output += "-";
			} else if ((box % 2 == 0 || box == 21) && rolls [i - 1] + rolls [i] == 10) { // Spare, second roll or final roll
				output += "/";
			} else if (rolls [i] == 10 && box >= 19) { // Strike in 10 frame
				output += "X";
			} else if (rolls [i] == 10) { // Strike + empty slot, first roll
				output += "X ";
			} else { // Normal
				output += rolls [i].ToString ();
			}
		}

		return output;
	}
}
