using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	private float prevVolume;
	private float prevDiff;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();	
				
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		prevVolume = volumeSlider.value;
		
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		prevDiff = difficultySlider.value;
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume(volumeSlider.value); 
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);		
		levelManager.LoadLevel("01a Start");
	}
	
	public void Cancel(){
		volumeSlider.value = prevVolume;
		difficultySlider.value = prevDiff;
	}
	
	public void SetDefault(){
		volumeSlider.value = 0.5f;
		difficultySlider.value = 2;
	}
}
