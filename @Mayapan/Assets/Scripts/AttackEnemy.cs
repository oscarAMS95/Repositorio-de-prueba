using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour{
	public int damaged = 5;
	public int critico = 2;
	public float timeHit = 0.6f;
	private float timer = 0f;
	public GameObject player;
	//private Animator anim;
	//private AudioSource audi;

	private void OnTriggerEnter(Collider collider){
		if (collider.tag == player.tag){
			collider.GetComponent<DamagePlayer>().Damaged(damaged);
			Debug.Log("Primer Ataque de " + damaged);
			//animacion
			//audio
		}
	}
	private void OnTriggerStay(Collider collider){
		if (collider.tag == player.tag){
			timer += Time.deltaTime;
			if (timer >= timeHit){
				collider.GetComponent<DamagePlayer>().Damaged(damaged * critico);
				timer = 0f;
				Debug.Log("Ataque de" + damaged * critico);
				//animacion
				//audio
			}
		}
	}
	private void OnTriggerExit(Collider collider){
		timer = 0f;
	}
}