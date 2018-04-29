using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Spawner myLaneSpawner; 
	
	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent)
			projectileParent = new GameObject("Projectiles");
		SetMyLaneSpawner();
	}
	
	void Update() {
		if(IsAttackerAheadInLane())
			GetComponent<Animator>().SetBool ("IsAttacking", true);
		else
			GetComponent<Animator>().SetBool ("IsAttacking", false);
	}
	
	void SetMyLaneSpawner(){
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner thisSpawner in spawners){
			if (thisSpawner.transform.position.y == transform.position.y){
				myLaneSpawner = thisSpawner;
				return;
			}
		}
		Debug.LogError(name + " can't find its spawner");
		
		// Or just
		// myLaneSpawner = GameObject.Find("Line " + transform.position.y);
	}
	
	bool IsAttackerAheadInLane(){
		if(myLaneSpawner.transform.childCount <=0)
			return false;
					
		foreach (Transform attacker in myLaneSpawner.transform){
			if(attacker.position.x > transform.position.x)
				return true;				
		}
		return false;
	}
	
	private void Fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
