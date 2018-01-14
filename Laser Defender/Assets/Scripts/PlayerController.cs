using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public GameObject projectile;
	public float projectileSpeed = 5;
	public float fireRate = 0.2f;
	public float health = 250;
	public AudioClip fireSound;
	public AudioClip dieSound;
	
	private float padding;	
	private float xmin;
	private float xmax;
	private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("Health").GetComponent<ScoreKeeper>();
		scoreKeeper.Health(health);
	
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		padding = this.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * this.transform.localScale.x;
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	void Fire(){
		float projectileSize = projectile.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * projectile.transform.localScale.y;
		float yPos = this.transform.position.y + this.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * this.transform.localScale.y + projectileSize;
		Vector3 startPosition = new Vector3(this.transform.position.x, yPos, this.transform.position.z);
		
		GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector2(0, projectileSpeed);
		
		AudioSource.PlayClipAtPoint(fireSound, this.transform.position, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 moving = new Vector3(Time.deltaTime * speed, 0, 0);
		Vector3 moving = Vector3.right * speed * Time.deltaTime;
	
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			this.transform.position -= moving;
		} else 
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			this.transform.position += moving;
		} 
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.000001f, fireRate); 
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
	 	
		float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
		
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
	}
	
	void OnTriggerEnter2D (Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile)
			health -= missile.GetDamage();		
		if (health <= 0){
			LevelManager lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
			//AudioSource.PlayClipAtPoint(dieSound, this.transform.position);
			lm.LoadLevel("Win");			
			Destroy(gameObject);
			health = 0;
		}
		Debug.Log("Fire!");
		scoreKeeper.Health(health);
	}
}
