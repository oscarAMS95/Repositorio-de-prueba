using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
    }

    void OnTriggerStay(Collider other) {
        //Debug.Log("cock  sucker");
        if(other.tag == "Player") {
            fire.SetActive(true);
        }
    }
}
