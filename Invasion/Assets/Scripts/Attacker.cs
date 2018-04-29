using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	
	[Tooltip("Average number of seconds between appearances")]
	public float seenEverySeconds;
	
	private float currentSpeed;
	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed *Time.deltaTime);
		
		if(!currentTarget){
			GetComponent<Animator>().SetBool("IsAttacking",false);
		}
	}
	
	public void SetSpeed (float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if (health){
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}
