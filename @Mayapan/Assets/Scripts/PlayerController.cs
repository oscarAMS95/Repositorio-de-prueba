using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator anim;

    /*Variables publicas*/
    public float hSpeed = 6.0f;
    public float jImpulse = 7.0f;
    public float gravity = 20.0f;
    public float jumpingTime = 0.6f;
    public AudioSource pie;
    public AudioSource salto;
    public static int lives = 3;
    public static int health = 50;
	public static int points = 0;

    private bool JumpingAllowed = true;
    private float jumpingTimeCounter;
    private bool isJumping;
    private bool facingRight;
    private bool onLadder;

    private bool isRunning;

    private float currentGravity;

    

    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start(){
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //pie = GetComponent<AudioSource>();
        isJumping = false;
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate(){
        Jump();                                                         /*Accion de saltar (salto corto y prolongado)*/
        Move();                                                        /*Accion de movimiento horizontal*/
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ladder") {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("metarig|Running"))
                transform.rotation = Quaternion.Euler(0, 90, 0);
            moveDirection = Vector3.zero;
            onLadder = true;
            
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Ladder") {
            JumpingAllowed = false;
            onLadder = true;
        } 
    }

    private void OnTriggerExit(Collider other) {
        JumpingAllowed = true;
        onLadder = false;
        anim.SetBool("isOnStair", false);
        
    }

    private void Jump()
    {
        if (characterController.isGrounded && Input.GetButton("Jump"))  /*Salto simple*/
        {
            salto.Play();
            anim.SetBool("isJumping", false);
            jumpingTimeCounter = jumpingTime;
            isJumping = true;
            moveDirection.x = 0;
            if(JumpingAllowed)
                moveDirection.y = jImpulse;
        }
        /*A partir de aqui comienza el salto prolongado*/
        if (Input.GetButton("Jump") && isJumping)
        {
            anim.SetBool("isJumping", true);
            if (jumpingTimeCounter > 0) /*Tiempo de salto prolongado*/
            {
                if(JumpingAllowed)
                    moveDirection.y += jImpulse / 50;       /*Adicion de movimiento*/
                jumpingTimeCounter -= Time.deltaTime;   /*Reduccion del tiempo de salto prolongado*/
            }
            else
                isJumping = false;                      /*Se acaba el tiempo de salto*/
        }
        if (Input.GetButtonUp("Jump"))                  /*Si se deja de presionar el boton de salto*/                
            isJumping = false;                          /*Ya no se puede extender el salto*/
        if (characterController.isGrounded) {
            currentGravity = 0;
            /*if(!isJumping) {
                anim.SetBool("isJumping", false);
            }*/
            anim.SetBool("isJumping", false); /*Borrar si nofunciona*/
        }
        else {
            if(currentGravity <= gravity)
                if(JumpingAllowed)
                    currentGravity++;
        }
        if(JumpingAllowed)
            moveDirection.y -= currentGravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);       /*Actualizacion del movimiento*/
    }

    private void Move()
    {
        float displacement = Input.GetAxis("Horizontal") * hSpeed;

        if (displacement != 0)
        {
            if(!isRunning){
                pie.loop = true;
                pie.Play();
                isRunning = true;
            }
            moveDirection.x = displacement;
            anim.SetBool("isRunning", true);
            transform.localScale.Set(0, 0, 0.2f * Input.GetAxis("Horizontal"));
            if(displacement > 0 && !facingRight || displacement < 0 && facingRight) {
                if(!onLadder) {
                    Flip();
                }
            }
        }
        else
        {
            isRunning = false;
            pie.Stop();
            anim.SetBool("isRunning", false);
        }
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, (facingRight) ? 90 : 270, 0);
    }
}
