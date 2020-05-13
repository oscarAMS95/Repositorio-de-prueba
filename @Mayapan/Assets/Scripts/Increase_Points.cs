using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase_Points : MonoBehaviour
{
    public void OneUp(){
        if(PlayerController.points<99)
            PlayerController.points += 1;
        Debug.Log("Puntos = " + PlayerController.points);
    }
}
