using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : MonoBehaviour
{
    public GameObject pickup;
    public float multiplier = 2.4f; 
    public float duration = 5f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //Efecto del powerup va aqui con un Instantiate
        Debug.Log("El power up salto");
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.jImpulse *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);
        stats.jImpulse /= multiplier;
        Destroy(gameObject);
    }
}