using UnityEngine;
using System.Collections;

public class MusicalPlayer : MonoBehaviour {
	static MusicalPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	void Awake(){
		//Debug.Log ("Music player AWAKE " + GetInstanceID());
		if (instance != null && instance != this) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}
	
	void OnLevelWasLoaded(int level) {
		music.Stop();
		if(level == 1)
			music.clip = startClip;
		if(level == 2)
			music.clip = gameClip;
		if(level == 3){
			music.clip = endClip;
			music.volume = 0.35f;
		}
		else
			music.volume = 0.025f;
		music.loop = true;
		music.Play();
	}
}
