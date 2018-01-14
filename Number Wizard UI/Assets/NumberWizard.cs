using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	
	int maxGuessesAllowed = LevelManager.dificulty;	
	public Text text;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		NextGuess();		
	}
	
	void NextGuess () {		
		maxGuessesAllowed -= 1;
		if (maxGuessesAllowed < 0){
			Application.LoadLevel("Win");
		}
		else {
			guess = Random.Range(min, max+1);
			text.text = guess.ToString();
		}
	}
		
	public void GuessHigher() {
		min = guess;
		NextGuess();
	} 
	
	public void GuessLower() {
		max = guess;
		NextGuess();	
	} 
}