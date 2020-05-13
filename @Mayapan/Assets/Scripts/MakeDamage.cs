using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeDamage : MonoBehaviour{
    public int damaged = 10;
	public float timeHit = 0.6f;
	private float timer = 0f;

	private void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player")
			collider.GetComponent<DamagePlayer>().Damaged(damaged);
	}
	private void OnTriggerStay(Collider collider){
		if (collider.tag == "Player"){
			timer += Time.deltaTime;
			if (timer >= timeHit){
				collider.GetComponent<DamagePlayer>().Damaged(damaged);
				timer = 0f;
			}
		}
	}
	private void OnTriggerExit(Collider collider){
		timer = 0f;
	}
}
