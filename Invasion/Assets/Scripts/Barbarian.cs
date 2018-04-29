using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Barbarian : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if(!obj.GetComponent<Defender>()){
			return;
		}
		if(obj.GetComponent<Shield>()){
			anim.SetTrigger("JumpTrigger");
		} else{
			anim.SetBool("IsAttacking",true);
			attacker.Attack(obj);
		}
	}
}
