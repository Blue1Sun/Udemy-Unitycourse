using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	
	void Start(){
		audioSource = this.GetComponent<AudioSource>();
		
		float volume = PlayerPrefsManager.GetMasterVolume();
		SetVolume(volume);
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip clip = levelMusicChangeArray[level];
		if (clip && audioSource.clip != clip){
			audioSource.Stop();
			audioSource.clip = levelMusicChangeArray[level];
			audioSource.loop = true;
			//audioSource.volume = PlayerPrefsManager.GetMasterVolume();
			audioSource.Play();
		}
	}
	
	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
}
