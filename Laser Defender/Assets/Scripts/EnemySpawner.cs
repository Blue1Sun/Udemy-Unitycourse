using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float width = 10;
	public float height = 5;
	public float speed = 1;
	public float spawnDelay = 0.5f;
	
	private float xmin;
	private float xmax;
	private Vector3 moving;

	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		xmin = leftmost.x + width/2;
		xmax = rightmost.x - width/2;
		
		moving = Vector3.right * speed * Time.deltaTime;
		
		SpawnUntilFull();
	}
	
	void SpawnEnemy(){
		foreach(Transform child in this.transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child.transform;
		} 
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += moving;
		if (this.transform.position.x > xmax || this.transform.position.x < xmin){
			moving = moving * -1;
		}		
		if (AllMembersDead()){
			SpawnUntilFull();
		}
	}
	
	Transform NextFreePosition(){
		
		foreach(Transform freePosition in this.transform){
			if (freePosition.childCount == 0){
				return freePosition;
			}
		}
		return null;
	}
	
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if (freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}
	
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in this.transform){
			if (childPositionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
}