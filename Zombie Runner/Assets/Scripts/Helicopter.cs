using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

    void Update()
    {
        if (called)
        {
            Transform target = GameObject.Find("LandingArea(Clone)").transform;
            
            if (Mathf.Abs(transform.position.x - target.position.x) > 1 && Mathf.Abs(transform.position.z - target.position.z) > 1)
            {
                Vector3 destination = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 300);
                transform.position = destination;
                transform.position = new Vector3(transform.position.x, 200, transform.position.z);
                
            }
            else if (Mathf.Abs(transform.position.y - target.position.y) > 1)
            {
                rigidBody.velocity = Vector3.down * 25;
            }
            else
            {
                rigidBody.velocity = Vector3.zero;
            }
        }
    }

	void OnDispatchHelicopter (){

        called = true;
	}
}
