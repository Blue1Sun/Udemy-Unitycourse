using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	public static bool spawnersIsOn = true;
	
	void Start(){
		spawnersIsOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if (isTimeToSpawn (thisAttacker) && spawnersIsOn){
				Spawn (thisAttacker);
			}
		}
	}
	
	void Spawn (GameObject attacker){
		GameObject myAttacker = Instantiate(attacker) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn (GameObject attackerObj){
		Attacker attacker = attackerObj.GetComponent<Attacker>();
		
		float meanSpawnDelay = attacker.seenEverySeconds; 
		float spawnsPerSeconds = 1 / meanSpawnDelay; 
		
		if(Time.deltaTime > meanSpawnDelay){ //слишком затяжной кадр
			Debug.LogWarning("Capped by frame rate");	
		}
				
		float threshold = spawnsPerSeconds * Time.deltaTime / 5; //спавн во фрейм с учетом 5 линий
		
		return (Random.value < threshold);
	}
}
