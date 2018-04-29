using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public float levelTimeSec = 100;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	
	private GameObject winLabel;
	
	void Start() {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		
		winLabel = GameObject.Find("Win");
		if (!winLabel){
			Debug.LogWarning("No Win Label found");
		}
		else{
			winLabel.SetActive(false);
		}
	}
		
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelTimeSec;
		
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelTimeSec);
		if (timeIsUp && !isEndOfLevel){
			Spawner.spawnersIsOn = false;
			
			foreach (GameObject taggedObj in GameObject.FindGameObjectsWithTag("destroyOnWin"))
				Destroy(taggedObj);	
			
			isEndOfLevel = true;
			winLabel.SetActive(true);
			Invoke("LoadNextLevel", audioSource.clip.length);
			audioSource.Play();
		}
	}
	
	void LoadNextLevel() {
		GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
	}
}
