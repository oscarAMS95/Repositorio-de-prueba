using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLives : MonoBehaviour
{
    public void OneUp(){
        if(PlayerController.lives<99)
            PlayerController.lives += 1;
        Debug.Log("Vidas = " + PlayerController.lives);
    }
}
