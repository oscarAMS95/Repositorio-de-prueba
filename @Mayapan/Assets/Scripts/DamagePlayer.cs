using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
	//private Animator anim;
	//private AudioSource audi;
	public void Damaged(int amount){
		if (PlayerController.health > 0)
		{
			PlayerController.health -= amount;
			//animacion
			//audio
			Debug.Log("Daño de " + amount);
			if (PlayerController.health == 0)
				Debug.Log("Game Over");
				//animacion
				//audio
		}
	}
}