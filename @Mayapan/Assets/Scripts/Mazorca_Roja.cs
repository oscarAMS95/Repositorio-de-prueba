using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazorca_Roja : MonoBehaviour
{
        void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            other.GetComponent<IncreaseLives>().OneUp();
            Destroy(gameObject);
        }
    }
}
