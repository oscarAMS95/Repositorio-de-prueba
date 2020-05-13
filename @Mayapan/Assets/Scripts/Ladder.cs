using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float vSpeed = 5;
    private CharacterController characterController;
    public PlayerController pc;
    public Animator anim;
    private bool isClimbing = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other) {
        float displacement = Input.GetAxis("Vertical");
        if(other.tag == "Ladder") {
        	anim.SetBool("isOnStair", true);
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("metarig|Running")) {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if(displacement != 0) {
            	if(isClimbing == false) {
            		isClimbing = true;
            		anim.SetBool("isClimbing", true);
            	}
                moveDirection.y = displacement * vSpeed;
                characterController.Move(moveDirection * Time.deltaTime);
            } else {
            	if(isClimbing == true) {
            		isClimbing = false;
            		anim.SetBool("isClimbing", false);
            	}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
