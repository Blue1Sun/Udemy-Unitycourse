using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	void OnTriggerStay2D(Collider2D collider){
		if(collider.gameObject.GetComponent<Attacker>())
			GetComponent<Animator>().SetTrigger("UnderAttackTrigger");
	}
}
