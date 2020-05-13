using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSounds : MonoBehaviour
{
    public AudioSource pie;
    private bool step;
    private bool iddle;
    // Start is called before the first frame update
    void Start()
    {
        step = false;
        iddle = true;
    }

    void Update(){
        
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ladder"){
            Debug.Log("hello");
        }
        if(other.tag == "Ground"){
            step = true;
            pie.Play();
        }
            
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            pie.Play();
        }
    }


}
