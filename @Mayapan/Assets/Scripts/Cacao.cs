using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacao : MonoBehaviour{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            other.GetComponent<Increase_Points>().OneUp();
            Destroy(gameObject);
        }
    }
}
