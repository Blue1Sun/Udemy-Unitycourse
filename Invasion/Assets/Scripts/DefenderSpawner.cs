using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find("Defenders");
		if (!parent)
			parent = new GameObject("Defenders");
		
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 pos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		
		if(defender){
			int defenderCost = defender.GetComponent<Defender>().starCost;
			if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
				SpawnDefender (pos, defender);
			}
			else{
				Debug.Log ("Don't have enough stars!");
			}
		}
	}

	void SpawnDefender (Vector2 pos, GameObject defender)
	{
		GameObject thisDefender = Instantiate (defender, pos, Quaternion.identity) as GameObject;
		thisDefender.transform.parent = parent.transform;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		
		return new Vector2 (newX, newY);
	}
	
	Vector2 CalculateWorldPointOfMouseClick(){
		
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector2 worldUnits = Camera.main.ScreenToWorldPoint(new Vector3 (mouseX, mouseY, distanceFromCamera));
				
		return worldUnits;
	}
}
