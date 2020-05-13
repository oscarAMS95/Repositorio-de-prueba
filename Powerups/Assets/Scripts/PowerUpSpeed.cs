using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickup;
    public float multiplier = 2.4f;
    public float duration = 7f;
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
        playerMovement stats = player.GetComponent<playerMovement>();
        stats.runSpeed *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);
        stats.runSpeed /= multiplier;
        Destroy(gameObject);
    }
}
