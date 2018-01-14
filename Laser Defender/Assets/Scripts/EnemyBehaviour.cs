using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 150;
	public float projectileSpeed = 20;
	public GameObject projectile;
	public float shotsPerSec = 0.5f;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip dieSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D (Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile)
			health -= missile.GetDamage();
			if (health <= 0){
				AudioSource.PlayClipAtPoint(dieSound, this.transform.position, 0.1f);
				Destroy(gameObject);				
				scoreKeeper.Score(scoreValue);
			}
	}
	
	void Fire(){
		float projectileSize = projectile.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * projectile.transform.localScale.y;
		float yPos = this.transform.position.y - this.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * this.transform.localScale.y - projectileSize;
		Vector3 startPosition = new Vector3(this.transform.position.x, yPos, this.transform.position.z);
		
		GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		
		AudioSource.PlayClipAtPoint(fireSound, this.transform.position, 0.1f);
	}
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSec;
		if(Random.value < probability){
			Fire ();
		}
		//InvokeRepeating("Fire", 0.000001f, 0.2f);
	}
	
	
}
