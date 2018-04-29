using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fading : MonoBehaviour {

	public static float fadingTime = 1;
	
	private Image fadePanel;
	private Color curColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadingTime && fadingTime > 0){
			float alphaChange = Time.deltaTime / fadingTime;
			curColor.a -= alphaChange;
			fadePanel.color = curColor;	
		}
		else {
			gameObject.SetActive(false);
			fadingTime = 0;
		}
	}
}
