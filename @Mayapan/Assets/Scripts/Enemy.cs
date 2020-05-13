using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Renderer Object;
    private bool materialState = false;
    public Material nombreMaterial1;
    public Material nombreMaterial2;

    public int health = 100;
   // public GameObject deathEffect;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //Die();
        }
    }

   /* void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMaterial()
    {
        if(materialState == false)
        {
            Object.GetComponent<MeshRenderer> ().material = nombreMaterial2;
            materialState = true;
        }
        else
        {
            Object.GetComponent<MeshRenderer> ().material = nombreMaterial1;
            materialState = false;
        }
    }
}
