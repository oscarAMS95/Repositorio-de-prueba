using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLife : MonoBehaviour
{
    public void Increase(){
        if(PlayerController.health <= 90)
            PlayerController.health += 10;
		Debug.Log("Health: " + PlayerController.health);
    }
}
