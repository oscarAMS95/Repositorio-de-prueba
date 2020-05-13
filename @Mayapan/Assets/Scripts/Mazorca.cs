using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazorca : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            other.GetComponent<IncreaseLife>().Increase();
            Destroy(gameObject);
        }
    }
}
