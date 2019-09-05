using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall; 
	public AudioClip initialCallReply; 

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void OnMakeInitialHeliCall(){
		print (name + " OnMakeInitialHeliCall");

		audioSource.clip = initialHeliCall;
		audioSource.Play ();

		Invoke ("InitialReply", initialHeliCall.length + 2f);
	}

	void InitialReply(){
		audioSource.clip = initialCallReply;
		audioSource.Play ();

		BroadcastMessage ("OnDispatchHelicopter");
	}
}
