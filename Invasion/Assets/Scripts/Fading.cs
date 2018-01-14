using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fading : MonoBehaviour {

	public float fadingTime;
	
	private Image fadePanel;
	private Color curColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadingTime){
			float alphaChange = Time.deltaTime / fadingTime;
			curColor.a -= alphaChange;
			fadePanel.color = curColor;	
		}
		else {
			gameObject.SetActive(false);
		}
	}
}
