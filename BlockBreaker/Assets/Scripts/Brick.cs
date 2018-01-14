using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breackableNumber = 0;
	public GameObject smoke;
	
	private int timesHit;	
	private LevelManager levelmanager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breackableNumber++;
		}
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		if (isBreakable){
			AudioSource.PlayClipAtPoint (crack, transform.position);
			HandleHits();
		}	
	}
	
	void HandleHits(){
		timesHit++;	
		int maxHits = hitSprites.Length + 1;
		if (maxHits <= timesHit){
			breackableNumber--;
			if (breackableNumber <= 0)
			{
				levelmanager.LoadNextLevel();
				breackableNumber = 0;
			}
			PuffSmoke();
			Destroy(gameObject);
		} else{
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject brickSmoke = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		brickSmoke.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("No sprite found!");
		}
	}
}
