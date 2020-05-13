using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Animator anim;
    public AudioSource atackSound;
    void Start(){
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.K))
       {
            Attack();
            atackSound.Play();
       }
    }

    void Attack()
    {
        /*Attack action*/ 
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        anim.SetTrigger("isAttacking");
        foreach(Collider2D enemy in enemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<Enemy>().changeMaterial();
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
