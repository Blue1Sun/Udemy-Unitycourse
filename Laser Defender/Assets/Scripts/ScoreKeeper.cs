using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int curScore = 0;
	private Text myText;

	void Start(){
		myText = this.GetComponent<Text>();
	}

	public void Score(int points)
	{
		curScore += points;
		myText.text = curScore.ToString();
	}
	
	public void Health(float hp)
	{
		myText.text = hp.ToString();
	}
	
	public static void Reset()
	{
		curScore = 0;
	}
}
