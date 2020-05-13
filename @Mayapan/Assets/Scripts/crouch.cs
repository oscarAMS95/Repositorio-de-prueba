using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour{
    public BoxCollider player;
    public Animator anim;

    // Start is called before the first frame update
    void Start(){
        player = player.GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.DownArrow)){
            player.size = new Vector3(1, 0.33f, 1);
            player.center = new Vector3(0, -0.33f, 0);
            anim.SetBool("isCrouching", true);
        }
        else{
            player.size = new Vector3(1, 1, 1);
            player.center = new Vector3(0, 0, 0);
            anim.SetBool("isCrouching", false);
        }
        
    }
}
