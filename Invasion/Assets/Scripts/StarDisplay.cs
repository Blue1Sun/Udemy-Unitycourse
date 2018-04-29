using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	
	public enum Status {SUCCESS, FAILURE};
	
	private Text starsText;
	private int stars = 100;
	

	void Start(){
		starsText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddStars(int amount){
		stars += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int amount){
		if(stars >= amount)	{
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		starsText.text = stars.ToString();
	}
}
